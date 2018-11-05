using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoZe_Main
{
    class licenseManager
    {
        private static licenseManager instance;
        private Dictionary<int, string> licenseTypes;
        private string decodedLicenseInfo;

        public licenseManager GetInstance()
        {
            return returnOrCreateInstance();
        }

        private licenseManager returnOrCreateInstance()
        {
            if (instance == null)
                instance = new licenseManager();
            else
                return instance;
        }

        public bool isLicenseActive()
        {
            return false;
        }

        private void checkLicense()
        {

        }

        public string GetInfoString()
        {
            return "";
        }


    }

}
