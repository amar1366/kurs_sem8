using lab4.Storage.Migrations;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace lab4.Services
{
    public class ConvertToExcel : IConvertToExcel
    {
        private readonly CenterDataContext _dbContext;

        public ConvertToExcel(CenterDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<byte[]> ConvertDbToExcel()
        {
            var departments = await _dbContext.Department.AsNoTracking().ToListAsync();
            var universities = await _dbContext.University.AsNoTracking().ToListAsync();
            var professors = await _dbContext.Professor.AsNoTracking().ToListAsync();


            bool error = false;
            if(departments == null) error = true;
            if(universities == null) error = true;
            if(professors == null) error = true;
            
            if(error) return new byte[0];
            
            try
            {
                byte[] excelData;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
            
                    var departmentsSheet = package.Workbook.Worksheets.Add("Департаменты");
                    departmentsSheet.Cells[1, 1].Value = "Id";
                    departmentsSheet.Cells[1, 2].Value = "Название";

                    Parallel.For(0, departments.Count,  i =>
                    {
                        departmentsSheet.Cells[i + 2, 1].Value = departments[i].dNomber;
                        departmentsSheet.Cells[i + 2, 2].Value = departments[i].dName;
                    });
            
                    var universitiesSheet = package.Workbook.Worksheets.Add("Университеты");
                    universitiesSheet.Cells[1, 1].Value = "Id";
                    universitiesSheet.Cells[1, 2].Value = "Название";
            
                    Parallel.For(0, universities!.Count, i =>
                    {
                        universitiesSheet.Cells[i + 2, 1].Value = universities[i].uNomber;
                        universitiesSheet.Cells[i + 2, 2].Value = universities[i].uName;
                    });
            
                    var professorsSheet = package.Workbook.Worksheets.Add("Профессора");
                    professorsSheet.Cells[1, 1].Value = "Id";
                    professorsSheet.Cells[1, 2].Value = "Фамилия";
                    professorsSheet.Cells[1, 3].Value = "Имя";
                    professorsSheet.Cells[1, 4].Value = "Отчество";
                    professorsSheet.Cells[1, 5].Value = "Дата рождения";

                    Parallel.For(0, professors!.Count, i =>
                    {
                        professorsSheet.Cells[i + 2, 1].Value = professors[i].pNomber;
                        professorsSheet.Cells[i + 2, 2].Value = professors[i].surname;
                        professorsSheet.Cells[i + 2, 3].Value = professors[i].name;
                        professorsSheet.Cells[i + 2, 4].Value = professors[i].middlename;
                        professorsSheet.Cells[i + 2, 5].Value = professors[i].birthday.ToString("dd-MM-yyyy");
                    });
            
                    excelData = await package.GetAsByteArrayAsync();
                }
            
                return excelData;
            }
            catch
            {
                return new byte[0];
            }
        }
    }
}
