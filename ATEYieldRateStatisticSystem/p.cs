using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ATEYieldRateStatisticSystem
{
    public  class p
    {

        public static string AppFolder = @".\ATEYieldRate";






        public static bool checkFolder()
        {

            if (!Directory.Exists(AppFolder))
            {

                try
                {
                    Directory.CreateDirectory(AppFolder);
                }
                catch (Exception ex)
                {

                    return false;
                }
  

            }

            return true;
        }

    }
}
