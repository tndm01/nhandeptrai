﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace NNShop.Common
{
    public static class ReportHelper
    {
        public static Task GenerateXls<T>(List<T> datasorce, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(nameof(T));
                    ws.Cells["A1"].LoadFromCollection<T>(datasorce, true, TableStyles.Light1);
                    ws.Cells.AutoFitColumns();
                    pck.Save();
                }
            });
        }
    }
}