using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.InfrastructureLayer
{
    public interface IJobsService
    {
        void OneTime();
        public void Delayed();
        void Recurring();
        void Continuation();

    }
}
