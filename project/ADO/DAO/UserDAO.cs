using ADO.Models.Models;
using ADO.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAO
{
    public class UserDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static UserDAO instance;

        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return instance; }
            private set { instance = value; }
        }

        private UserDAO() { }

        public bool Login(string text1, string text2)
        {
            if (text1 == null || text2 == null) return false;
            text2 = SCR.Instance.Encode(text2);
            ACCOUNT user = new ACCOUNT();
            if (db.ACCOUNTs.Count(c => c.USERNAME == text1
            && c.PASSWORK == text2) > 0)
                return true;
            return false;
        }

        public bool ChangePass(ACCOUNT user, string old, string passnew, string repeat)
        {
            if (user == null) return false;
            if (old == null || passnew == null || repeat == null) return false;
            if (passnew != repeat) return false;
            if (SCR.Instance.Decryption(user.PASSWORK) != old) return false;

            string pass = SCR.Instance.Decryption(passnew);

            user.PASSWORK = pass;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public ACCOUNT GetUserByUserName(string text)
        {
            return db.ACCOUNTs.FirstOrDefault(c => c.USERNAME == text);
        }

        public bool Add(NHAN_VIEN nhanvien, string quyen, string username, string pass, string repeat)
        {
            if (quyen == null || username == null || pass == null || repeat == null) return false;
            if (UserDAO.Instance.GetCountUserByUserName(username) > 0) return false;
            if (QuyenDAO.Instance.GetCountQuyenByName(quyen) == 0) return false;
            if (pass != repeat) return false;

            LEVEL_USER q = QuyenDAO.Instance.GetQuyenByName(quyen);

            ACCOUNT user = new ACCOUNT();

            pass = SCR.Instance.Encode(pass);

            user.USERNAME = username;
            user.PASSWORK = pass;
            user.ID_QUYEN = q.ID;
            user.ID_NHANVIEN = nhanvien.ID;

            db.ACCOUNTs.Add(user);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Update(ACCOUNT user, string quyen, string pass, string repeat)
        {
            LEVEL_USER q = new LEVEL_USER();
            if (quyen != null)
            {
                if (QuyenDAO.Instance.GetCountQuyenByName(quyen) > 0)
                {
                    if (user.ID_QUYEN != q.ID)
                    {
                        q = QuyenDAO.Instance.GetQuyenByName(quyen);
                        user.ID_QUYEN = q.ID;
                    }
                }
            }

            if (pass != null && repeat != null && pass == repeat)
            {
                pass = SCR.Instance.Encode(pass);
                user.PASSWORK = pass;
            }

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        private int GetCountUserByUserName(string username)
        {
            return db.ACCOUNTs.Count(c => c.USERNAME == username);
        }

        public int GetCountUserByNhanVien(NHAN_VIEN nv)
        {
            return db.ACCOUNTs.Count(c => c.ID_NHANVIEN == nv.ID);
        }

        internal bool DeleteNhanVien(int id)
        {
            var users = from u in db.ACCOUNTs.Where(c => c.ID_NHANVIEN == id) select u;

            foreach (var user in users)
            {
                db.ACCOUNTs.Attach(user);
                user.ID_NHANVIEN = null;
            }

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
