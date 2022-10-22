using System.Collections.Generic;
using System.ServiceModel;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace Server
{
    [ServiceContract]
    public interface DataServerInterface
    {
        [OperationContract]
        Jobs downloadJobs(int id);

        [OperationContract]
        List<Jobs> connectServer(int id);

        [OperationContract]
        bool FinishingJob(int id, ActiveJobs aj);
    }
}
