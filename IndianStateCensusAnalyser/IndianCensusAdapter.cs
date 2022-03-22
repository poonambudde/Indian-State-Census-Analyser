﻿using IndianStateCensusAnalyser.CustomException;
using IndianStateCensusAnalyser.DTO;
using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> censusStateAndCode;

        //Method to load csv file return in the form of dictionary
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                censusStateAndCode = new Dictionary<string, CensusDTO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                    }
                    string[] coloumn = data.Split(',');
                    if (csvFilePath.Contains("IndiaStateCode.csv"))
                        censusStateAndCode.Add(coloumn[0], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                    if (csvFilePath.Contains("IndianPopulation.csv"))
                        censusStateAndCode.Add(coloumn[0], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
                return censusStateAndCode;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}