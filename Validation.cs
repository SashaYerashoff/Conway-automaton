using System;

namespace ConwayAutomaton
{
    public class Validation
    {
        public short ValidateShort()
        {

            short checkOk; // ar šo mainīgo atgriežam funkcijas darbības rezultātu
            short output;  //šeit glabāsim starprezultātu ja TryParse atgriezīs "true"
            string input; // ar šo mainīgo nolasam ievadu
            string mistake = "It's almost certainly not an integer!"; // Teksts paziņojumam par kļūdu (šīs mainīgais nav obligāts)
            string whatToDo = "Please, try to input the digit with no coma - it certainly shoud work then: "; // Teksts kas paskaidro, ko vajag ievadīt (šīs mainīgais nav obligāts)
            bool result; // TryParse pārbaudīs mūsu ievadu un ja tas būs Int32, atgriezīs true 

            input = Console.ReadLine(); // Ievads
            result = Int16.TryParse(input, out output); // Pārbaude

            while (result == false) //Kamēr netiks saņemts Int32, cikls ziņos par kļūdu un prasīs jaunu ievadu  
            {
                Console.WriteLine(mistake); //izvada paziņojumu par kļūdu
                Console.Write(whatToDo);    //Piedāvā vēlreiz ievadīt skaitli

                input = Console.ReadLine(); // nolasa ievadu

                result = Int16.TryParse(input, out output); // pārbauda vai ir skaitlis un vai vajag atkartot visu no jauna
            }
            checkOk = output; //Ja ievadā bija skaitlis (TryParse == true) tad piešķiram to funkcijas izvadam

            return checkOk; // funkcijas izvads
        }

        public int ValidateDimensions()
        {
            short input = ValidateShort();
            while (input < 3 || input > 60)
            {
                Console.Write("Your field either to small [<3] or to big [>60]. Try once again: ");
                input = ValidateShort();
            }
            return input;
        }
    }
}
