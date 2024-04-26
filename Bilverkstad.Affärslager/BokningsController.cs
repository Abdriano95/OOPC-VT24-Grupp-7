using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Affärslager
{
    public class BokningsController
    {
        public BokningsController() {}

        public void AddBokning(Bokning bokning)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Bokning!.Add(bokning);
                unitOfWork.SaveChanges();
            }
        }


    }
}
