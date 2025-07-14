using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        /* Steps of solving the problem: 
         * 1) reading the data from the file 
         * 2) initalize the simulation table and performance measures
         * 3) for each customer generate a random variable to get his 
         *    arrival time based on the random variable in which range
         *    then calculate arrival time and time service begins
         * 4) for each customer generate a random variable from 1 to 100 
         * 5) for the first customer select the right range from server 1 and get its value
         * 6) calculate the end time,idle time, delay time
         * 7) after these calculations calculate Average waiting time (in the queue). 
                Maximum queue length. 
                Probability that a customer wait in the queue. 

                Per Server:
                Average service time per server. 
                Utilization of each server 
                Probability that a server is in idle state.
         */
        public void Read_File(string filename)
        {
            // read from file and fill some data
            string[] lines = File.ReadAllLines(@"C:\Users\sondo\Documents\Modeling-and-Simulation\Task 1\MultiQueueSimulation\TestCases\" + filename + ".txt");

            int i = 0;
            while (i < lines.Length)
            {

                // Using .TrimEnd to remove extra spaces after the data
                string line = lines[i].TrimEnd();

                // escaping white lines
                if (string.IsNullOrEmpty(line))
                {

                    i++;
                    continue;
                }
                switch (line)
                {

                    case "NumberOfServers":
                        i++;
                        NumberOfServers = Int32.Parse(lines[i]);
                        break;
                    case "StoppingNumber":
                        i++;
                        StoppingNumber = Int32.Parse(lines[i]);
                        break;
                    case "StoppingCriteria":
                        i++;
                        if (Int32.Parse(lines[i]) == 1)
                            StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                        else if (Int32.Parse(lines[i]) == 2)
                            StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                        break;
                    case "SelectionMethod":
                        i++;
                        if (Int32.Parse(lines[i]) == 1)
                            SelectionMethod = Enums.SelectionMethod.HighestPriority;
                        else if (Int32.Parse(lines[i]) == 2)
                            SelectionMethod = Enums.SelectionMethod.Random;
                        else if (Int32.Parse(lines[i]) == 3)
                            SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                        break;
                    case "InterarrivalDistribution":
                        i++;
                        i = Make_Tables(lines, i, InterarrivalDistribution);
                        break;
                    default:
                        Server server = new Server();
                        i++;
                        i = Make_Tables(lines, i, server.TimeDistribution);
                        Servers.Add(server);
                        break;
                }
                i++;
            }
            selection_method();
        }
        private int Make_Tables(string[] lines, int i, dynamic val)
        {
            int c = 0;
           
            while (i < lines.Length && lines[i].Contains(','))
            {
                TimeDistribution timeDistribution = new TimeDistribution();

                string[] split = lines[i].Split(',');

                timeDistribution.Time = Int32.Parse(split[0]);
                timeDistribution.Probability = Decimal.Parse(split[1]);
                if (c == 0)
                {
                    timeDistribution.CummProbability = timeDistribution.Probability;
                    timeDistribution.MinRange = 1;
                    timeDistribution.MaxRange = Decimal.ToInt32(timeDistribution.Probability * 100);
                }
                else
                {
                    timeDistribution.CummProbability = timeDistribution.Probability + val[c - 1].CummProbability;
                    timeDistribution.MinRange = Decimal.ToInt32(val[c - 1].CummProbability * 100) + 1;
                    timeDistribution.MaxRange = Decimal.ToInt32(timeDistribution.CummProbability * 100);
                }
                c++;
                val.Add(timeDistribution);
                i++;
            }
            return i--;
        }

        /// <summary>
        /// Calculating the simulation table based on the selected method 
        /// contains initalizing variables used, applying the seleccted method, calculating measurements for the whole system and measurements for each server
        /// </summary>
        public void selection_method()
        {
            // initializing variables needed for each selection method
            //Which Server empty will assign the customer.
            decimal lastendtime = 0;
            decimal num_Customer_Wait = 0, CustmerWaitTime = 0;
            Random random = new Random();
            int begin = 0;

            // as initalizing these variables used whatever the choosen servers criteria so it used here before calculating the tables
            initalizing_variables();

            // Calculating the table based on the choosen selection method
            if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {
                calculating_full_simulation_highest_priority(ref lastendtime, ref CustmerWaitTime, ref num_Customer_Wait, ref random, ref begin);
            }
            else if (SelectionMethod == Enums.SelectionMethod.Random)
            {
                calculating_full_simulation_random(ref CustmerWaitTime, ref num_Customer_Wait, ref random, ref begin);
            }
            else if (SelectionMethod == Enums.SelectionMethod.LeastUtilization)
            {
                calculating_full_simulation_least_utilization(ref lastendtime, ref CustmerWaitTime, ref num_Customer_Wait, ref random, ref begin);
            }

            // Output calculations
            system_outputs_performance_measures_simulation(ref lastendtime, ref num_Customer_Wait, ref CustmerWaitTime);
            //each server calculations
            Measure_per_Server();
        }

        /// <summary>
        /// initialize variables used in calculating the table
        /// which are simulation table,its customer number and servers id
        /// </summary>
        public void initalizing_variables()
        {
            // To remove all data in the simulation table if there are variable(s)
            SimulationTable.Clear();
            for (int i = 0; i < StoppingNumber; i++)
            {
                SimulationTable.Add(new SimulationCase());
                SimulationTable[i].CustomerNumber = i + 1;
            }
            for (int j = 0; j < NumberOfServers; j++)
            {
                Servers[j].ID = j + 1;
            }

        }

        /// <summary>
        /// calculating the whole table based on the random selection method 
        /// </summary>
        /// <param name="CustomerWait"></param>
        /// <param name="CustmerWaitTime"></param>
        public void calculating_full_simulation_random(ref decimal CustmerWaitTime, ref decimal CustomerWait, ref Random random, ref int begin)
        {

            int wait = 0, Old_Arrival_Time = 0; // Old_Arrival_Time : Column 4
            bool mini;
            bool maxi;

            for (int i = 0; i < StoppingNumber; i++)
            {

                if (i == 0)
                {
                    // initalizing the variables 
                    SimulationTable[i].RandomInterArrival = 1;
                    // As this is the first customer then there is no time he waited for 
                    SimulationTable[i].InterArrival = 0;
                    SimulationTable[i].ArrivalTime = 0;
                    // To generate a random number to know which service range will take its time 
                    SimulationTable[i].RandomService = random.Next(1, 101);
                    Servers[0].TotalWorkingTime = 0;

                    // first customer : all servers are (idle) 
                    for (int j = 0; j < Servers[0].TimeDistribution.Count; j++)
                    {
                        // checking ranges to get the right range 
                        mini = SimulationTable[i].RandomService >= Servers[0].TimeDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomService <= Servers[0].TimeDistribution[j].MaxRange;
                        // calculate service time
                        if (mini && maxi)
                        {
                            // Getting the right time based on the range
                            SimulationTable[i].ServiceTime = Servers[0].TimeDistribution[j].Time;
                            SimulationTable[i].AssignedServer.ID = Servers[0].ID;
                            // calculating the ranges of the operation 
                            SimulationTable[i].StartTime = begin;
                            Servers[0].FinishTime = begin + SimulationTable[i].ServiceTime;
                            SimulationTable[i].EndTime = Servers[0].FinishTime;
                            // To calculate the number of customers waited
                            wait = begin - Old_Arrival_Time;
                            SimulationTable[i].TimeInQueue = wait;
                            // Check if the customer waited in the queue
                            if (0 != SimulationTable[i].TimeInQueue)
                            {
                                CustmerWaitTime += SimulationTable[i].TimeInQueue;
                                CustomerWait += 1;
                            }
                            // To calculate the total number of units (like hours) the server worked
                            Servers[0].TotalWorkingTime += SimulationTable[i].ServiceTime;
                        }
                    }
                }
                else
                {
                    // generate a number to get its range from interarrival distribution table to know the time when
                    // the customer comes  
                    SimulationTable[i].RandomInterArrival = random.Next(1, 101);
                    for (int j = 0; j < InterarrivalDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomInterArrival >= InterarrivalDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomInterArrival <= InterarrivalDistribution[j].MaxRange;
                        // to get Inter Arrival time Column 3 , ArrivalTime Column 4 
                        if (mini && maxi)
                        {
                            // getting the interarrival time (A) from interarrival distribution table
                            SimulationTable[i].InterArrival = InterarrivalDistribution[j].Time;
                            // calculating the arrival time based on the rule t(i) = a(i) + t(i-1)
                            SimulationTable[i].ArrivalTime = SimulationTable[i].InterArrival + Old_Arrival_Time;
                            Old_Arrival_Time = SimulationTable[i].ArrivalTime;
                        }
                    }
                    // generating a number to get the range of the server to get the service time
                    SimulationTable[i].RandomService = random.Next(1, 101);

                    int empty_ser_exists = 0, min_ser_time = 10000000, emp_ser_indx = 0;
                    List<int> emp_server = new List<int>();
                    for (int j = 0; j < Servers.Count; j++)
                    {
                        // search about empty server to get service time for new customer
                        bool empty_server_search = SimulationTable[i].ArrivalTime >= Servers[j].FinishTime;
                        if (empty_server_search)
                        {
                            empty_ser_exists = 1;
                            // get all servers that are enable to select random between these servers
                            emp_server.Add(Servers[j].ID);
                        }
                        // to get the minimum service finish time if all servers are busy
                        if (min_ser_time > Servers[j].FinishTime)
                        {
                            min_ser_time = Servers[j].FinishTime;
                            emp_ser_indx = j;
                        }
                    }
                    // there are empty servers case
                    if (empty_ser_exists == 1)
                    {
                        int servID;
                        // To generate a random number to select the server number
                        if (emp_server.Count > 1)
                            servID = random.Next(1, emp_server.Count);
                        else
                            servID = emp_server[0];
                        // to get the right range to get service time from the server  servID table
                        for (int k = 0; k < Servers[servID - 1].TimeDistribution.Count; k++)
                        {
                            mini = SimulationTable[i].RandomService >= Servers[servID - 1].TimeDistribution[k].MinRange;
                            maxi = SimulationTable[i].RandomService <= Servers[servID - 1].TimeDistribution[k].MaxRange;
                            if ((mini && maxi) || false)
                            {
                                // getting the time of the service
                                SimulationTable[i].ServiceTime = Servers[servID - 1].TimeDistribution[k].Time;
                                // the start of the operation 
                                begin = SimulationTable[i].ArrivalTime;
                                SimulationTable[i].StartTime = begin;
                                // assign the server id 
                                SimulationTable[i].AssignedServer.ID = Servers[servID - 1].ID;
                                // Calculating the end time
                                Servers[servID - 1].FinishTime = begin + SimulationTable[i].ServiceTime;
                                SimulationTable[i].EndTime = Servers[servID - 1].FinishTime;
                                // As there is no customer in the queue then its value will be 0
                                SimulationTable[i].TimeInQueue = 0;
                                // Update the total working hours for this server
                                Servers[servID - 1].TotalWorkingTime += SimulationTable[i].ServiceTime;
                                break;
                            }
                        }
                    }

                    if (empty_ser_exists == 0)
                    {
                        // all servers is busy (Select min finish time for all servers)
                        for (int j = 0; j < Servers[emp_ser_indx].TimeDistribution.Count; j++)
                        {
                            mini = SimulationTable[i].RandomService >= Servers[emp_ser_indx].TimeDistribution[j].MinRange;
                            maxi = SimulationTable[i].RandomService <= Servers[emp_ser_indx].TimeDistribution[j].MaxRange;
                            if (mini && maxi)
                            {
                                SimulationTable[i].ServiceTime = Servers[emp_ser_indx].TimeDistribution[j].Time;
                                break;
                            }
                        }
                        // as there is a customer waiting in the queue then when the server finishs its current operation,
                        // the customer will go and make his operation  
                        SimulationTable[i].StartTime = Servers[emp_ser_indx].FinishTime;
                        // To calculate the delay time
                        SimulationTable[i].TimeInQueue = Servers[emp_ser_indx].FinishTime - SimulationTable[i].ArrivalTime;
                        // calculate the customers waiting time
                        CustmerWaitTime += SimulationTable[i].TimeInQueue;
                        // update the number of customers 
                        CustomerWait += 1;
                        // calculating the operation finish time
                        SimulationTable[i].EndTime = SimulationTable[i].StartTime + SimulationTable[i].ServiceTime;
                        Servers[emp_ser_indx].FinishTime = SimulationTable[i].EndTime;
                        // putting then server id selected in the simulation table 
                        SimulationTable[i].AssignedServer.ID = Servers[emp_ser_indx].ID;
                        // updating the total working time 
                        Servers[emp_ser_indx].TotalWorkingTime += SimulationTable[i].ServiceTime;
                    }
                }
            }
        }
        /// <summary>
        /// calculate the simulation table based on highest priority 
        /// </summary>
        /// <param name="lastendtime"></param>
        /// <param name="CustomerWaitTime">time which the customer waits</param>
        /// <param name="CustomerWait"></param>
        /// <param name="random">to generate a random number</param>
        /// <param name="begin">the begining of the operations</param>
        public void calculating_full_simulation_highest_priority(ref decimal lastendtime, ref decimal CustmerWaitTime, ref decimal CustomerWait, ref Random random, ref int begin)
        {
            bool mini;
            bool maxi;
            for (int i = 0; i < StoppingNumber; i++)
            {
                if (i == 0)
                {
                    // Server 1 : has highest priority
                    // Assign Customer to any server
                    // initalizing the variables 
                    SimulationTable[i].RandomInterArrival = 1;
                    // As this is the first customer then there is no time he waited for 
                    SimulationTable[i].InterArrival = 0;
                    SimulationTable[i].ArrivalTime = 0;
                    // To generate a random number to know which range will take its time 
                    SimulationTable[i].RandomService = random.Next(1, 101);
                    for (int j = 0; j < Servers[0].TimeDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomService >= Servers[0].TimeDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomService <= Servers[0].TimeDistribution[j].MaxRange;
                        if (mini && maxi)
                        {
                            // calculating the service time from getting the right range from the random variable 
                            SimulationTable[i].ServiceTime = Servers[0].TimeDistribution[j].Time;
                            break;
                        }
                    }
                    // calculating the start,end time of the operation
                    SimulationTable[i].StartTime = begin;
                    SimulationTable[i].EndTime = begin + SimulationTable[i].ServiceTime;
                    // assigning the id
                    SimulationTable[i].AssignedServer.ID = Servers[0].ID;
                    // passing that the customer didn't wait in the queue
                    SimulationTable[i].TimeInQueue = 0;
                    // store the finish time in the server 
                    Servers[0].FinishTime = begin + SimulationTable[i].ServiceTime;
                    // calculate the total working time of the server
                    Servers[0].TotalWorkingTime += SimulationTable[i].ServiceTime;
                    // pass the time when the server will be idle
                    lastendtime = SimulationTable[i].EndTime;

                }
                else
                {
                    // generating a random interarrival number to get the range
                    SimulationTable[i].RandomInterArrival = random.Next(1, 101);
                    // get interarrival time
                    for (int j = 0; j < InterarrivalDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomInterArrival >= InterarrivalDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomInterArrival <= InterarrivalDistribution[j].MaxRange;
                        if (mini && maxi)
                        {
                            // getting the time in which the random variable is in its range 
                            SimulationTable[i].InterArrival = InterarrivalDistribution[j].Time;
                            // calculating the arrival time based on the formula T(i) = A(i) + T(i-1)
                            SimulationTable[i].ArrivalTime = SimulationTable[i].InterArrival + SimulationTable[i - 1].ArrivalTime;
                        }
                    }
                    // generating the random service time
                    SimulationTable[i].RandomService = random.Next(1, 101);

                    // To Select Server which have highest priority
                    int min_index = 10000000, flag = 0;
                    for (int j = 0; j < Servers.Count; j++)
                    {
                        // check server (idle , busy )
                        bool empty_server = SimulationTable[i].ArrivalTime >= Servers[j].FinishTime;
                        if (empty_server)
                        {
                            // this Server is idle....
                            if (Servers[j].ID < (min_index + 1))
                            {
                                min_index = Servers[j].ID - 1;
                                // min_index : index for Server which have highest priority
                            }
                            // To know if there exist an empty server or not
                            flag = 1;
                        }

                    }

                    if (flag == 0)
                    {
                        // All Servers is busy
                        // Select min Finish Time for Server
                        int server_finish_time = 10000000;
                        for (int j = 0; j < Servers.Count; j++)
                        {
                            if (Servers[j].FinishTime < server_finish_time)
                            {
                                server_finish_time = Servers[j].FinishTime;
                                min_index = j;
                            }
                        }
                    }

                    // min_index : Server which assing customer to it.
                    // Get Service Time
                    for (int j = 0; j < Servers[min_index].TimeDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomService >= Servers[min_index].TimeDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomService <= Servers[min_index].TimeDistribution[j].MaxRange;
                        if (mini && maxi)
                        {
                            // the service time of the operation
                            SimulationTable[i].ServiceTime = Servers[min_index].TimeDistribution[j].Time;
                            break;
                        }
                    }

                    // calculating waiting time in the queue
                    bool cust_not_waits = Servers[min_index].FinishTime <= SimulationTable[i].ArrivalTime;
                    if (cust_not_waits)
                        SimulationTable[i].TimeInQueue = 0;
                    else
                        SimulationTable[i].TimeInQueue = Servers[min_index].FinishTime - SimulationTable[i].ArrivalTime;
                    // calculate the start time of the operation
                    begin = SimulationTable[i].ArrivalTime + SimulationTable[i].TimeInQueue;
                    SimulationTable[i].StartTime = begin;
                    // calculating the end time of the operation 
                    SimulationTable[i].EndTime = begin + SimulationTable[i].ServiceTime;
                    // assign the server id to the simulation table
                    SimulationTable[i].AssignedServer.ID = Servers[min_index].ID;
                    Servers[min_index].FinishTime = begin + SimulationTable[i].ServiceTime;
                    // calculate the total time operations take in this server
                    Servers[min_index].TotalWorkingTime += SimulationTable[i].ServiceTime;
                    // to check if the customer waits in the queue or not
                    if (SimulationTable[i].TimeInQueue != 0)
                    {
                        CustmerWaitTime += SimulationTable[i].TimeInQueue;
                        CustomerWait += 1;
                    }
                }
            }
        }
        /// <summary>
        /// calculate the simulation table based on least_utilization
        /// </summary>
        public void calculating_full_simulation_least_utilization(ref decimal lastendtime, ref decimal CustmerWaitTime, ref decimal CustomerWait, ref Random random, ref int begin)
        {
            bool mini;
            bool maxi;

            for (int i = 0; i < StoppingNumber; i++)
            {
                if (i == 0)
                {
                    // Assign Customer to any server
                    // initalizing the variables 
                    SimulationTable[i].RandomInterArrival = 1;
                    SimulationTable[i].InterArrival = 0;
                    // As this is the first customer then there is no time he waited for 
                    SimulationTable[i].ArrivalTime = 0;
                    // generate the service variable to search for its range and get the service time of this variable
                    SimulationTable[i].RandomService = random.Next(1, 101);

                    for (int j = 0; j < Servers[0].TimeDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomService >= Servers[0].TimeDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomService <= Servers[0].TimeDistribution[j].MaxRange;

                        if ( mini && maxi)
                        {
                            // assigning the right service time based on its range
                            SimulationTable[i].ServiceTime = Servers[0].TimeDistribution[j].Time;
                            break;
                        }
                    }
                    // calculating the start time of the operation
                    SimulationTable[i].StartTime = begin;
                    // calculating the end time of the operation 
                    SimulationTable[i].EndTime = begin + SimulationTable[i].ServiceTime;
                    // assign the server id
                    SimulationTable[i].AssignedServer.ID = Servers[0].ID;
                    // calculate the time the customer waits in the queue
                    SimulationTable[i].TimeInQueue = 0;
                    Servers[0].FinishTime = begin + SimulationTable[i].ServiceTime;
                    Servers[0].TotalWorkingTime += SimulationTable[i].ServiceTime;
                    lastendtime = SimulationTable[i].EndTime;
                }
                else
                {
                    // check servers TotalWorkingTime to get least utilization
                    int min_working_time_index = 100000000, STWT = 100000000;
                    // loop to calculate the minimum server has less work
                    for (int j = 0; j < Servers.Count; j++)
                    {
                        if (Servers[j].TotalWorkingTime < STWT)
                        {
                            STWT = Servers[j].TotalWorkingTime;
                            min_working_time_index = j;
                        }
                    }

                    // generate a random variable to calculate the time on which the customer comes to make an operation
                    SimulationTable[i].RandomInterArrival = random.Next(1, 101);

                    for (int j = 0; j < InterarrivalDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomInterArrival >= InterarrivalDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomInterArrival <= InterarrivalDistribution[j].MaxRange;
                        // to get Inter Arrival time Column 3 , ArrivalTime Column 4 
                        if (mini && maxi)
                        {
                            SimulationTable[i].InterArrival = InterarrivalDistribution[j].Time;
                            // T(i) = A(i) + T(i-1)
                            SimulationTable[i].ArrivalTime = SimulationTable[i].InterArrival + SimulationTable[i - 1].ArrivalTime;
                        }
                    }
                    // generate a service variable
                    SimulationTable[i].RandomService = random.Next(1, 101);

                    for (int j = 0; j < Servers[min_working_time_index].TimeDistribution.Count; j++)
                    {
                        mini = SimulationTable[i].RandomService >= Servers[min_working_time_index].TimeDistribution[j].MinRange;
                        maxi = SimulationTable[i].RandomService <= Servers[min_working_time_index].TimeDistribution[j].MaxRange;
                        if (mini && maxi)
                        {
                            // get the service time
                            SimulationTable[i].ServiceTime = Servers[min_working_time_index].TimeDistribution[j].Time;
                            break;
                        }
                    }

                    // to know if the customer waits for a time
                    // and calculate the waiting time if exists
                    if (Servers[min_working_time_index].FinishTime <= SimulationTable[i].ArrivalTime)
                        SimulationTable[i].TimeInQueue = 0;
                    else
                        SimulationTable[i].TimeInQueue = Servers[min_working_time_index].FinishTime - SimulationTable[i].ArrivalTime;
                    begin = SimulationTable[i].ArrivalTime + SimulationTable[i].TimeInQueue;
                    // calculate the start time of the operation
                    SimulationTable[i].StartTime = begin;
                    // calculate the end time of the operation
                    SimulationTable[i].EndTime = begin + SimulationTable[i].ServiceTime;
                    // assign server number to the simulation table
                    SimulationTable[i].AssignedServer.ID = Servers[min_working_time_index].ID;
                    Servers[min_working_time_index].FinishTime = begin + SimulationTable[i].ServiceTime;
                    // calculate the total working time for the server
                    Servers[min_working_time_index].TotalWorkingTime += SimulationTable[i].ServiceTime;
                    // calculate the delay and number of customers waited
                    if (SimulationTable[i].TimeInQueue != 0)
                    {
                        CustmerWaitTime += SimulationTable[i].TimeInQueue;
                        CustomerWait += 1;
                    }

                }
            }
        }

        /// <summary>
        /// calculating last_end_time, AverageWaitingTime, WaitingProbability, max queue length
        /// </summary>
        /// <param name="CustomerWait"></param>
        /// <param name="CustmerWaitTime"></param>
        public void system_outputs_performance_measures_simulation(ref decimal lastendtime, ref decimal CustomerWait, ref decimal CustmerWaitTime)
        {
            // System Output Performance Measures...............
            // get the whole system finishs
            lastendtime = SimulationTable[SimulationTable.Count - 1].EndTime;
            // calculate the average waiting time
            PerformanceMeasures.AverageWaitingTime = CustmerWaitTime / StoppingNumber;
            // calculate the probability of waiting 
            PerformanceMeasures.WaitingProbability = CustomerWait / StoppingNumber;
            int max_queue_len = 0;
            bool x;
            bool y;
            // to Calculate Max Queue Length
            for (int j = 1; j < lastendtime; j++)
            {
                for (int w = 0; w < SimulationTable.Count; w++)
                {
                    // To know if the start of the operation greater than the customer arrival
                    x = SimulationTable[w].ArrivalTime <= j;
                    y = SimulationTable[w].StartTime > j;
                    if (x && y)
                    {
                        max_queue_len++;
                    }
                    else
                    {
                        // to know if the maximum length variable is less than the maxqueuelen variable of the performance measures
                        if (PerformanceMeasures.MaxQueueLength < max_queue_len)
                        {
                            PerformanceMeasures.MaxQueueLength = max_queue_len;
                            break;
                        }
                        max_queue_len = 0;
                    }
                }
            }
        }

        public void Measure_per_Server()
        {
            // Calculate Measure for each server
            // calculate the end time of the system
            decimal last_time = SimulationTable[SimulationTable.Count - 1].EndTime;
            if (last_time == 0)
                last_time = 1;
            // for each server calculate the number of customer assigned to it
            for (int i = 0; i < Servers.Count; i++)
            {
                decimal customer = 0;

                for (int j = 0; j < SimulationTable.Count; j++)
                {
                    if (SimulationTable[j].AssignedServer.ID == i + 1)
                    {
                        customer += 1;
                    }
                }
                // calculate the idle probability 
                Servers[i].IdleProbability = (decimal)(last_time - Servers[i].TotalWorkingTime) / last_time;

                if (customer != 0)
                    Servers[i].AverageServiceTime = Servers[i].TotalWorkingTime / customer;
                else
                    Servers[i].AverageServiceTime = 0;

                Servers[i].Utilization = Servers[i].TotalWorkingTime / last_time;
            }
        }
    }
}
