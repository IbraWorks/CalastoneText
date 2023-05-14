// See https://aka.ms/new-console-template for more information

using System.Reflection;
using CalastoneTest.Services;
using CalastoneTest.Strategies;
using CalastoneTest.Wrappers;

const string filePath = "Data/AliceWonderlandText.txt";
var fileWrapper = new FileWrapper();
var text = await fileWrapper.ReadAllTextAsync(filePath);

var filterOne =  new TextFilterService(new VowelsInMiddleOfWordFilter());
var filterTwo = new TextFilterService(new ThreeOrMoreWordsFilter());
var filterThree = new TextFilterService(new TWordFilter());

var filteredByVowelsText = filterOne.FilterText(text);
var filteredByCharCount = filterTwo.FilterText(filteredByVowelsText);
var filteredByTWords = filterThree.FilterText(filteredByCharCount);
Console.WriteLine(filteredByTWords);