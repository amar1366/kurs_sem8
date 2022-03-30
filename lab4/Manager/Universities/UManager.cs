using lab4.Storage.Entity;
using lab4.Storage.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab4.Manager.Universities
{
    public class UManager : InterfaceUManager
    {
        public readonly CenterDataContext _dbContext;

        public UManager(CenterDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<University> AddUniversity(Guid DepartamentId, URequest request)
        {
            var entity = new University
            {
                uNomber = Guid.NewGuid(),
                uName = request.uName,
                DepartamentId = DepartamentId

            };
            _dbContext.University.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<University> UpdateUniversity(Guid id, URequest request)
        {
            var entity = await _dbContext.University.FirstOrDefaultAsync(g => g.uNomber == id);
            entity.uName = request.uName;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Guid> DeleteUniversity(Guid id)
        {
            var entity = await _dbContext.University.FirstOrDefaultAsync(g => g.uNomber == id);
            _dbContext.University.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity.DepartamentId;
        }
        public async Task<University> GetById(Guid id)
        {
            var entity = await _dbContext.University.FirstOrDefaultAsync(g => g.uNomber == id);
            entity.Department = await _dbContext.Department.FirstOrDefaultAsync(g => g.dNomber == entity.DepartamentId);
            return entity;
        }
        public async Task<University> GetAllProfessors(Guid id)
        {
            var entity = await _dbContext.University.FirstOrDefaultAsync(g => g.uNomber == id);
            entity.Department = await _dbContext.Department.FirstOrDefaultAsync(g => g.dNomber == entity.DepartamentId);
            entity.Professors = await _dbContext.Professor.AsNoTracking().Where(g => g.UniversityId == entity.uNomber).ToListAsync();
            return entity;
        }
        //метод, который объединяет два списка, причем повторяющиеся сущности добавдляет лишь один раз
        public List<Professor> AddListProfessor(List<Professor> List1, List<Professor> List2)
        {
            if (List1.Count != 0)
            {
                if (List2.Count != 0)
                {
                    foreach (var entity in List2)
                    {
                        //проверяем наличие записи второго списка в первом, если записи нет, то в record = null
                        var record = List1.FirstOrDefault(g => g.pNomber == entity.pNomber);
                        if (record == null)
                        {
                            List1.Add(entity);
                        }
                    }
                }
                return List1;
            }
            else if (List2.Count != 0)
            {
                return List2;
            }
            return new List<Professor>();
        }
        public async Task<University> Searchprofessor(Guid id, string name, string text)
        {
            var entity = await _dbContext.University.AsNoTracking().FirstOrDefaultAsync(g => g.uNomber == id);
            entity.Department = await _dbContext.Department.AsNoTracking().FirstOrDefaultAsync(g => g.dNomber == entity.DepartamentId);
            text = text.Trim(' ');
            text = Regex.Replace(text, @"\s+", " ");
            name = name.ToLower();
            List<Professor> list = new List<Professor>();
            //получаем список профессоров 
            entity.Professors = await _dbContext.Professor.AsNoTracking().Where(g => g.UniversityId == id).ToListAsync();
            switch (name)
            {
                case "all":
                    DateTime date;
                    bool flag = false;
                    if (DateTime.TryParse(text, out date))
                    {
                        flag = true;
                    }
                    //осуществляем поиск по всем столбцам таблицы 
                    if (flag)
                    {
                        list = entity.Professors.Where(g => g.birthday == date).ToList();
                    }
                    else
                    {
                        list = entity.Professors.Where(g => (g.surname + " " + g.name + " " + g.middlename).Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                    //если ничего найти не удалось, пытаемся разбить строку text на несколько слов и осуществить поиск заново.
                    if (list.Count == 0)
                    {
                        if (flag == false)
                        {
                            //Разбиваем сроку text на подстроки с помощью метода Split и осуществляем цикл по полученному массиву
                            foreach (var word in text.Split(' '))
                            {
                               
                                //метод Contain - Возвращает значение, указывающее, встречается ли указанная строка внутри этой строки, используя указанные правила сравнения.
                                //StringComparison.OrdinalIgnoreCase - Сравнивать строки, используя правила обычной (двоичной) сортировки без учета регистра сравниваемых строк.
                                list = entity.Professors.Where(g => (g.surname + " " + g.name + " " + g.middlename).Contains(word, StringComparison.OrdinalIgnoreCase)).ToList();
                                entity.Professors = await Task.Run(() => AddListProfessor(entity.Professors, list));
                            }
                        }
                    }
                    else
                    {
                        entity.Professors = list;
                    }
                    break;
                case "date":
                    DateTime Date;
                    if (DateTime.TryParse(text, out Date))
                    {
                        entity.Professors = entity.Professors.Where(g => g.birthday == Date).ToList();
                    }
                    break;
                case "name":
                    entity.Professors = entity.Professors.Where(g => (g.surname + " " + g.name + " " + g.middlename).Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
            }
            return entity;
        }
    }
}
