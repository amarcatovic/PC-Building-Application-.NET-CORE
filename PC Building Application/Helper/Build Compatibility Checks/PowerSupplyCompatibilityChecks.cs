using PC_Building_Application.Data;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Helper.Build_Compatibility_Checks
{
    public class PowerSupplyCompatibilityChecks
    {
        public List<string> CheckPsuAndStoragesompatibility(PowerSupply psu, IEnumerable<Storage> storages)
        {
            var errorStrings = new List<string>();
            int noOfSataCablesRequired = 0;

            foreach (var storage in storages)
            {
                if (storage.Name != "M.2 SSD")
                    ++noOfSataCablesRequired;
            }

            if (psu.NoOfSATACables < noOfSataCablesRequired)
                errorStrings.Add($"There are {noOfSataCablesRequired} SATA drives, but Power supply has only {psu.NoOfSATACables} SATA power cables");


            return errorStrings;
        }
    }
}
