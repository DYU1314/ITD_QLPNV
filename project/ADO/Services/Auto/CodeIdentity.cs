using ADO.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Services.Auto
{
    internal class CodeIdentity
    {
        DatabaseContext db = new DatabaseContext();

        private static CodeIdentity instance;

        public static CodeIdentity Instance
        {
            get { if (instance == null) instance = new CodeIdentity(); return instance; }
            private set { instance = value; }
        }

        public CodeIdentity() { }

        private void SortList(List<int> number)
        {
            for (int i = 0; i < number.Count() - 1; i++)
            {
                for (int j = i + 1; j < number.Count(); j++)
                    if (number[i] > number[j])
                    {
                        int temp = number[i];
                        number[i] = number[j];
                        number[j] = temp;
                    }
            }
        }

        private int GetNumberInput(List<int> number)
        {
            int x = 0;
            int i = 0;
            while (i < number.Count())
            {
                if (number.Count() == 1)
                {
                    if (number[i] >= 2) { x = i + 1; break; }
                    if (number[i] < 2) { x = i + 2; break; }
                }
                if (number.Count() > 1)
                {
                    if (number[i] != i + 1) { x = i + 1; break; }
                    if (number[i] == number.Count()) { x = number[i] + 1; break; }
                }

                i++;
            }

            return x;
        }

        public string DepartmentCode()
        {
            if (db.PHONG_BANs.Count() > 0)
            {
                List<int> number = new List<int>();

                char[] separators = new char[] { 'P', 'B' };
                foreach (var item in db.PHONG_BANs)
                {
                    string[] subs = item.MAPB.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < subs.Length; i++)
                    {
                        number.Add(Convert.ToInt32(subs[i]));
                    }
                }

                SortList(number);

                int x = GetNumberInput(number);

                if (x > 0)
                {
                    if (x < 10)
                        return "PB00" + x;
                    if (x < 100)
                        return "PB0" + x;
                    return "PB" + x;
                }

            }
            return "PB001";
        }

        public string PositionCode()
        {
            if (db.CHUC_VUs.Count() > 0)
            {
                List<int> number = new List<int>();

                char[] separators = new char[] { 'C', 'V' };
                foreach (var item in db.CHUC_VUs)
                {
                    string[] subs = item.MACV.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < subs.Length; i++)
                    {
                        number.Add(Convert.ToInt32(subs[i]));
                    }
                }

                SortList(number);

                int x = GetNumberInput(number);

                if (x > 0)
                {
                    if (x < 10)
                        return "CV00" + x;
                    if (x < 100)
                        return "CV0" + x;
                    return "CV" + x;
                }

            }
            return "CV001";
        }

        public string StaffCode()
        {
            if (db.NHAN_VIENs.Count() > 0)
            {
                List<int> number = new List<int>();

                char[] separators = new char[] { 'N', 'V' };
                foreach (var item in db.NHAN_VIENs)
                {
                    string[] subs = item.MANV.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < subs.Length; i++)
                    {
                        number.Add(Convert.ToInt32(subs[i]));
                    }
                }

                SortList(number);

                int x = GetNumberInput(number);

                if (x > 0)
                {
                    if (x < 10)
                        return "NV00" + x;
                    if (x < 100)
                        return "NV0" + x;
                    return "NV" + x;
                }

            }
            return "NV001";
        }

    }
}
