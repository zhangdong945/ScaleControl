using ScaleControl.Models.Entities;
using System.IO;

namespace ScaleControl.Reports
{
    public class TicketPrinter
    {
        public void Print(WeighingRecord record, string templatePath)
        {
            // TODO: 集成 FastReport.OpenSource
            var ticket = GenerateTicketText(record);
            System.Diagnostics.Debug.Print(ticket);
        }

        public void ExportToPdf(WeighingRecord record, string templatePath, string outputPath)
        {
            // TODO: 集成 FastReport.OpenSource PDF导出
            var ticket = GenerateTicketText(record);
            File.WriteAllText(outputPath + ".txt", ticket);
        }

        private string GenerateTicketText(WeighingRecord record)
        {
            return $@"========== 磅单 ==========
磅单号: {record.TicketNo1}
车号: {record.TruckNo}
货物: {record.Product}
毛重: {record.Gross} kg
皮重: {record.Tare} kg
净重: {record.Net} kg
时间: {record.SecondDateTime}
=========================";
        }
    }
}
