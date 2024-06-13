﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace SupportLayer.Models;

[DebuggerDisplay(null, Name = "{Id} - {GreenHouse.Name}")]
public partial class OrderLocation
{
    [NotMapped]
    public string SeedTrayName { get; set; }

    [NotMapped]
    public short RestOfSeedTraysToBeLocated
    {
        get
        {
            return (short)(SeedTrayAmount - Blocks.Sum(x => x.SeedTrayAmount));
        }
    }

    [NotMapped]
    public short RestOfSeedlingToBeLocated
    {
        get
        {
            int seedTrays = SeedTrayAmount - Blocks.Sum(x => x.SeedTrayAmount);
            int alveolus = SeedTray.TotalAlveolus;
            return (short)(seedTrays * alveolus);
        }
    }
}
