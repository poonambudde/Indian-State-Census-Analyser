using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class StateCodeDataDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        // Parameterized Constructor Initializes a new instance of the class.
        public StateCodeDataDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
