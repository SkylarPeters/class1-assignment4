// Skylar Peters
// CIS 237
// 3/22/2021

using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment4
{
    class DroidCollection : IDroidCollection
    {
        // Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        // Private variable to hold the length of the Collection
        private int lengthOfCollection;

        // Constructor that takes in the size of the collection.
        // It sets the size of the internal array that will be used.
        // It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            // Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            // Set length of collection to 0
            lengthOfCollection = 8;
            // Add droids to the array
            droidCollection[0] = new JanitorDroid("Carbonite", "Red", true, false, true, true, false);
            droidCollection[1] = new ProtocolDroid("Vanadium", "White", 2);
            droidCollection[2] = new AstromechDroid("Quadranium", "Blue", true, true, true, true, 6);
            droidCollection[3] = new UtilityDroid("Carbonite", "White", false, false, false);
            droidCollection[4] = new UtilityDroid("Vanadium", "Green", true, false, true);
            droidCollection[5] = new ProtocolDroid("Quadranium", "Blue", 7);
            droidCollection[6] = new JanitorDroid("Quadranium", "Green", false, true, true, false, true);
            droidCollection[7] = new AstromechDroid("Tears Of A Jedi", "White", true, false, true, false, 3);
        }

        //public DroidCollection() { }

        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Color, NumberOfLanguages);
                // Increase the length of the collection
                lengthOfCollection++;
                // Return that it was successful
                return true;
            }
            // Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        // The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        // The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The last method that must be implemented due to implementing the interface.
        // This method iterates through the list of droids and creates a printable string that could
        // be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            // Declare the return string
            string returnString = "";

            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            // Return the completed string
            return returnString;
        }

        // Method to sort the droids based on what type of droid they are
        public void CategorySort()
        {
            // Create instances of the generic stack class for each type of droid
            GenericStack<IDroid> protocolStack = new GenericStack<IDroid>();
            GenericStack<IDroid> utilityStack = new GenericStack<IDroid>();
            GenericStack<IDroid> janitorStack = new GenericStack<IDroid>();
            GenericStack<IDroid> astromechStack = new GenericStack<IDroid>();

            // Create an instance of the generic queue class
            GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

            // Put each element from the array into a stack
            foreach (IDroid droid in droidCollection)
            { 
                // Null elements are not used
                if (droid != null)
                {
                    switch (droid.GetType().Name.ToString())
                    {
                        // Protocol stack
                        case "ProtocolDroid":
                            protocolStack.Push(droid);
                            break;
                        // Astromech stack
                        case "AstromechDroid":
                            astromechStack.Push(droid);
                            break;
                        // Janitor stack
                        case "JanitorDroid":
                            janitorStack.Push(droid);
                            break;
                        // Utility stack
                        case "UtilityDroid":
                            utilityStack.Push(droid);
                            break;
                    }
                }
            }

            // Empty the astromech stack into the queue
            while (astromechStack.IsEmpty != true)
            {
                droidQueue.Enqueue(astromechStack.Pop());
            }

            // Empty the janitor stack into the queue
            while (janitorStack.IsEmpty != true)
            {
                droidQueue.Enqueue(janitorStack.Pop());
            }

            // Empty the utility stack into the queue
            while (utilityStack.IsEmpty != true)
            {
                droidQueue.Enqueue(utilityStack.Pop());
            }

            // Empty the protocol stack into the queue
            while (protocolStack.IsEmpty != true)
            {
                droidQueue.Enqueue(protocolStack.Pop());
            }

            // Replace the droid collection array elements with the droid queue
            for (int i = 0; i < droidCollection.Length; i++)
            {
                if (droidQueue.IsEmpty != true)
                {
                    droidCollection[i] = droidQueue.Dequeue();
                }
            }
        }

        // Method to sort the droids based on total cost
        public void TotalCostSort()
        {
            MergeSort.Sort(this.droidCollection);
        }
    }
}
