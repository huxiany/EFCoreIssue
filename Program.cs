using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreTileTests.Entity;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace EFCoreTileTests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AnDaDbContext())
            {
                EnsureDBInitialized(db);

                DateTime queryBeginTime = DateTime.Now;
                var salesOrderIdParam = new MySqlParameter("@salesOrderId", 578);
                var tiles = getTiles(db, 578);
                DateTime queryEndTime = DateTime.Now;
                printTimeDiff(queryEndTime, queryBeginTime, "Tile query");

                tiles = getTiles(db, 578);

                DateTime query2EndTime = DateTime.Now;
                printTimeDiff(query2EndTime, queryEndTime, "Tile query 2");

                tiles = getTilesNull(db, 578);

                DateTime query3EndTime = DateTime.Now;
                printTimeDiff(query3EndTime, query2EndTime, "Tile query 3");


                tiles = getTilesNull(db, 578);

                DateTime query4EndTime = DateTime.Now;
                printTimeDiff(query4EndTime, query3EndTime, "Tile query 4");
            }
        }
        public static void EnsureDBInitialized(AnDaDbContext db)
        {
            db.Database.EnsureCreated();
            if (!db.Tiles.Any())
            {
                for (int i = 1; i < 7000; i++)
                {
                    var tile = new Tile { SalesOrderId = 578, MaterialSpec = new MaterialSpec { Price = 252, GradeId = 3, Notes = "test" + i.ToString() } };
                    db.Tiles.Add(tile);
                }

                db.SaveChanges();
            }
        }

        static void printTimeDiff(DateTime endTime, DateTime startTime, string operation)
        {
            Console.WriteLine($"{operation} costs: {(endTime - startTime).TotalSeconds} seconds");
        }

        static List<Tile> getTiles(AnDaDbContext db, int salesOrderId)
        {
            var salesOrderIdParam = new MySqlParameter("@salesOrderId", salesOrderId);
            return db.Tiles.ToList();
        }

        static List<Tile> getTilesNull(AnDaDbContext db, int salesOrderId)
        {
            var salesOrderIdParam = new MySqlParameter("@salesOrderId", salesOrderId);
            return db.Tiles
                    .FromSql(@"SELECT `Id`, null as MaterialSpec, `SalesOrderId` from Tiles where SalesOrderId = @salesOrderId", salesOrderIdParam)
                    .ToList();
        }
    }
}
