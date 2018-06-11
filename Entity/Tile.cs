using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreTileTests.Entity
{
    /// <summary>
    /// 工程板
    /// </summary>
    public class Tile
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public JsonObject<MaterialSpec> MaterialSpec { get; set; }
    }
}
