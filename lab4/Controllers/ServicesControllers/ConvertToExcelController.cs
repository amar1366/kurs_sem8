﻿using lab4.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class ConvertToExcelController : Controller
    {
        private readonly IConvertToExcel _convertToExcel;

        public ConvertToExcelController(IConvertToExcel convertToExcel)
        {
            _convertToExcel = convertToExcel;
        }

        [HttpGet]
        public IActionResult GetDbExcel()
        {
            var excelData = Task.Run(async () => await _convertToExcel.ConvertDbToExcel()).Result;
            if (excelData == null || excelData.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            string fileName = "DataBase.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(excelData, contentType, fileName);
        }
    }
}
