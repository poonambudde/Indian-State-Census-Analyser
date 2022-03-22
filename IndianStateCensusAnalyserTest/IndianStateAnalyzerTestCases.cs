using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.CustomException;
using IndianStateCensusAnalyser.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace IndianStateCensusAnalyzerTesting
{
    [TestClass]
    public class IndianStateAnalyzerTestCases
    {
        //UC1 - File Paths for indian state census
        string stateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        string stateCensusFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongFileNameIndianPopulation.csv";
        string wrongTypeFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";

        //UC2 - File paths for indian state codes
        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";
        string stateCodeFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongFileNameIndiaStateCode.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\DELL\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        

        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateRecords;
        Dictionary<string, CensusDTO> stateCodeRecords;

        [SetUp]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [Test]
        [TestCategory("Indian State Census")]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, stateCensusHeader);
            Assert.AreEqual(expected, stateRecords.Count);
        }

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [Test]
        [TestCategory("Indian State Census")]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        [TestCategory("Indian State Census")]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        [TestCategory("Indian State Census")]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        [TestCategory("Indian State Census")]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.1 Given correct path To ensure number of records matches
        [Test]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesCsvReturnStateRecords()
        {
            int expected = 36;
            stateCodeRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeFilePath, stateCodeHeader);
            Assert.AreEqual(expected, stateCodeRecords.Count);
        }

        //TC 2.2 Given incorrect file should return custom exception - File not found
        [Test]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }
    }
}