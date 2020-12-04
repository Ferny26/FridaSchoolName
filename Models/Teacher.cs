using System;
using System.Collections.Generic;
using System.Linq;
namespace FridaSchoolWeb.Models
{
    public class Teacher 
    {
        protected int _Id;
        protected string _names, _middleName, _lastName, _password, _curp, _rfc;
        protected DateTime _birthDate;
        protected const sbyte CordinatorHours = 10, BaseHours = 30, AsignatureHours=24;
        protected char _gender;
        protected bool _isBase;

        public Teacher(){}

        public Teacher(String[] information){
            _names = information[0];
            _middleName = information[1];
            _lastName = information[2];
            _birthDate = DateTime.Parse(information[3]);
            _gender = Convert.ToChar(information[4]);
            _password = information[5];
            //AssignedHours = 0;
            //AssignedGroups = 0;
            KeysGenerator();
        }

        public virtual sbyte GetHours()
        {
            if (_isBase)
            {
                return BaseHours;
            }else{
                return AsignatureHours;
            }
        }

        public int Age => DateTime.Now.Year - BirthDate.Year;  
        public int ID{get; set;}
        public string Names{get; set;}
        public DateTime BirthDate{get;set;}
        public string MiddleName{get; set;}
        public string LastName{get; set;}
        public string Password{get; set;}
        public string CURP{get; set;}
        public string RFC{get; set;}
        public char Gender{get; set;}
        public bool IsBase{get; set;}
        public string Roaster{get; set;}
      

         #region CURP and RFC
            /// <summary>
            /// This function generate the CURP from the personal information 
            /// </summary>
            public void CURPGenerator()
            {
                #region Full name preparation
                    string names = FilterBaseNames(_names);
                    string middleName = FilterBaseNames(_middleName);
                    string lastName = FilterBaseNames(_lastName);     
                #endregion 
                //Words array that can't be appeared in the CURP or RFC for the first 4 letters
                string [] swearWords = {"BACA","BAKA","BUEI","BUEY","CACA","CACO","CAGA","CAGO","CAKA","CAKO","COGE","COGI","COJA","COJE","COJI","COJO","COLA","CULO","FALO","FETO","GETA","GUEI","GUEY","JETA","JOTO","KACA","KACO","KAGA","KAGO","KAKA","KAKO","KOGE","KOGI","KOJA","KOJE","KOJI","KOJO","KOLA","KULO","LILO",
                "LOCA","LOCO","LOKA","LOKO","MAME","MAMO","MEAR","MEAS","MEON","MIAR","MION","MOCO","MOKO","MULA","MULO","NACA","NACO","PEDA","PEDO","PENE","PIPI","PITO","POPO","PUTA","PUTO","QULO","RATA","ROBA","ROBE","ROBO","RUIN","SENO","TETA","VACA","VAGA","VAGO","VAKA","VUEI","VUEY","WUEI","WEY"};  
                #region Character 1
                    //Take the first letter of the middle name, if it's a 'Ñ', will be replace for a 'X'
                    _curp += middleName[0] == 'Ñ' ? 'X' : middleName[0];     
                #endregion
                #region Character 2
                    //Take the first middlename vowel
                    foreach (char item in middleName.Substring(1))
                    {
                        if(item == 'A' || item == 'E' || item == 'I' || item == 'O' || item == 'U')
                        {
                            _curp += item;
                            break;
                        }
                    }  
                #endregion
                #region Character 3
                    //Take the first letter of the lastname, if it's a 'Ñ', will be replace for a 'X'
                    _curp += lastName[0] == 'Ñ' ? 'X' : lastName[0]; 
                #endregion

                #region Character 4
                    //Take the first letter of the names, if it's a 'Ñ', will be replace for a 'X'
                    _curp += names[0] == 'Ñ' ? 'X' : names[0]; 
                #endregion

                #region Verification of the frist 4 characters 
                    //Check if the string doesn't form a swear word in the array
                    if (swearWords.Contains(_curp))
                    {
                        //If yes, the first vowel is replace for a 'X'
                        _curp = _curp[0] + 'X' + _curp.Substring(2,2);  
                    }  
                #endregion
                #region Characters 5 to 11
                    //Take the year, month and day of birthday to 2 digits
                    _curp += $"{_birthDate:yy}{_birthDate:MM}{_birthDate:dd}";
                #endregion
                #region Character 12
                    //Concat the person gender 
                    _curp += _gender;
                #endregion
                #region Character 13
                    //Concat the identifiers for the Jalisco state 
                    _curp += "JC";
                #endregion
                #region Character 14 to 16
                    //Take the consonant in each case, without taking the first letter 
                    _curp += Consonant(_middleName.Substring(1));
                    _curp += Consonant(_lastName.Substring(1));
                    _curp += Consonant(_names.Substring(1));        
                #endregion
                #region Character 17
                    //If the year of birthday is lees than 2000, cancat a 0, else, concat an A
                    _curp += _birthDate.Year < 2000 ? '0' : 'A';   
                #endregion
                #region Caracter 18
                    //This digit is calculated from the sum of the multiplication of each value digit with their position
                    int amount = 0, counter = 18;
                    foreach (char item in _curp)
                    {
                        //If digit is a letter, the counter is multiplied for the value in ascii minus 55
                        //Else the digit is a number, it is multiplied for the counter
                        amount += (item >= 65 && item <= 90) ? (item > 78 ? (counter * (item - 54)) : (counter * (item - 55))) : (counter * (item - 48));
                        counter --;
                    }
                    //After that follow the next formula 
                    amount = 10 - (amount % 10); 
                    //If the result is a 10, it was replace for a 0
                    _curp += amount == 10 ? 0 : amount; 
                #endregion
            }
            public  void KeysGenerator()
            {
                CURPGenerator();
                //Take the base characaters for the RFC
                _rfc = _curp.Substring(0,10);
                //The next characters represent a homonymous key
                #region Character 11 and 12
                    //Variables
                    string numbers = string.Empty;
                    int amount = 0, residue = 0;
                    #region Letters values
                    string Data = string.Concat(_middleName," ",_lastName," ",_names);
                    //Take the each value that the letter represent acording from a stablished table and concat each value
                    foreach (char item in Data)
                    {
                        numbers += (item >= 65 && item <= 90) ? (item == 165 ? (item - 125) : item > 82 ? (item -51) : item > 73 ? (item - 53) : (item - 54)) : 
                        00;
                    }   
                    #endregion

                    #region Operation and construction of homonim letters
                        //Put a 0 to make string not pair 
                        numbers = '0' + numbers;
                        //Make the multiplication of 2 numbers with the last of this pair and sum all results
                        for (int i = 0; i < numbers.Length-1; i++)
                        {
                            amount +=  int.Parse(numbers.Substring(i,2)) * int.Parse(numbers.Substring(i+1,1));
                        }
                        //Take the last 3 digits 
                        amount = amount % 1000;
                        //Divide in two parts to take the letters that correspond
                        residue = amount % 34;
                        amount = amount / 34;
                        //with the funtion concat the letters
                        _rfc += HomonymousDigits(amount);
                        _rfc += HomonymousDigits(residue); 
                        
                    #endregion
                    #endregion
                    #region Character 13 
                        int digit = 0, counter = 13;

                        //Calculate the last digit from the sum of the multiplication of each value digit their position 
                        foreach (char item in _rfc)
                        {
                            digit += (char) ((item >= 65 && item <= 90) ? (item > 78 ? (counter * (item - 54)) : (counter * (item - 55))) : (counter * (item - 48)));
                            counter --;
                        }
                        //After that follow the next formula
                        digit = digit % 11; 
                        //Depending of the amount, asigns the correspond digit
                        _rfc += digit == 0 ? "0" : digit == 10 ? "A" : (11-digit).ToString();     
                    #endregion    
                }
                /// <summary>
                /// Convert the value that recived to respect letter acording a established table
                /// </summary>
                /// <param name="amount">Recive a int to convert a letter or number</param>
                /// <returns>Return a string with the correspond letter or number</returns>
                protected string HomonymousDigits(int amount){
                    string digit = string.Empty;
                    //If the amount is less than 9, take this number more 1
                    //If the amount is more than 9, take this number in each case, and convert int to char
                    if (amount<9)
                    {
                        digit +=amount+1;
                    }else if (amount > 22)
                    {
                        Convert.ToChar(amount + 57);
                    }else
                    {
                        Convert.ToChar(amount + 56);
                    }
                    return digit;
                }

                /// <summary>
                /// This function filter a string according the established rules 
                /// </summary>
                /// <param name="data"> The string to filter</param>
                /// <returns>Return the first word of the string before being filtered</returns>
                protected string FilterBaseNames (string data)
                {
                    //Separate the string by commas and convert it in a list
                    var words = data.Split(' ').ToList();
                    string[] Conjunctions = {"DE", "LA", "DEL"}; 
                    //Remake the list with the words that doesn't match with someone of the array 
                    words = words.Where(i => !Conjunctions.Contains(i)).ToList();
                    string[] ForbiddenNames = {"MARIA", "JOSE"};
                    //If some word in the list match with some in the array, this is deleted
                    if(words.Count >= 2 && ForbiddenNames.Contains(words[0])){
                        words.RemoveAt(0);
                    }
                    //Returns the first word
                    return words[0];
                }

                /// <summary>
                /// This function take the first consonant in the string
                /// </summary>
                /// <param name="data">string where the function will search the consonant</param>
                /// <returns>returns a char with the consonant</returns>
                protected char Consonant (string data)
                {
                    char consonant = ' ';
                    foreach (char item in data)
                    {
                        //Consonants array
                        char[] consonants = {'B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Y','Z'};
                        if(consonants.Contains(item))
                        {
                            //Returns the first char that found in the array 
                            consonant = item;
                            break;
                        }
                    }
                    return consonant;
                }
        #endregion
    }
}