using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
namespace EF.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var context = new EFContext();

            var students = context.SinhVien
                .Where(s => s.Lop == "21T2" && s.Tuoi >= 18 && s.Tuoi <= 20)
                .ToList();
            Console.WriteLine("Danh sách sinh viên:");
            foreach (var student in students)
            {
                Console.WriteLine($"Mssv: {student.MaSsv}, Họ tên: {student.Ten}, Tuổi: {student.Tuoi}, Lớp: {student.Lop}");
            }
            Console.ReadKey();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
