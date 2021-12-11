using System;
using System.Collections.Generic;
using System.Collections;
class program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Dictionary<string, danhba> danhb = new Dictionary<string, danhba>();
        Dictionary<string, danhba> danhsachchan = new Dictionary<string, danhba>();
        Dictionary<string, danhba> danhsach = new Dictionary<string, danhba>();
        danhb.Add("1", new danhba("1", "VTK", "0906889483", "hungsamgnuyen", "vantuankiet", "22/07/2002","TP HCM",30000));
        danhb.Add("2", new danhba("2", "VTT", "0909678860", "taolanhat2200", "vantuquyen", "2/1/2002", "HA NOI",50000));
        danhb.Add("3", new danhba("3", "kieotCK", "0907265337", "funfun1234", "lamquocnhan", "22/5/2002", "VUNG TAU",125000));
        danhb.Add("4", new danhba("4", "CK", "0907265337", "funfun1234", "lamquocnhan", "22/5/2002", "TP HCM",170300));
        danhb.Add("5", new danhba("5", "444CK", "0907265337", "funfun1234", "lamquocnhan", "22/5/2002", "DA NANG",90000));
        
        Random so = new Random();
        int ngaunhien = so.Next(1, 5);
    kiet:
        Console.Write("Nhập vào lựa chọn của bạn: ");
        int y = int.Parse(Console.ReadLine());
         
        switch (y)
        {
            case 1:
                DBquaysonhanh(danhb, ref danhsach);                
                
                break;
            case 2:
                Timkiemdanhba(danhb); break;
            case 3:
                Doitt(danhb); break;
            case 4:
                foreach (KeyValuePair<string, danhba> kt in danhb)
                {
                    Console.Write("SĐT của {0} ", kt.Value.getnhan());
                    Mangdt(kt.Value.getsdt());
                }
                break;
            case 5:
                Console.Write("Nhập tên người cần xóa:");
                string ten = Console.ReadLine();
                xoa(danhb, ten); break;
            case 6:
                inradanhba(danhb, danhsachchan, danhsach); break;
            case 7:
                chan(ref danhb, ref danhsachchan); break;
            case 8:
                gochan(ref danhb, ref danhsachchan); break;
            case 11:
                
                timvaiso(danhb ); break;
            case 12:
                Console.Write("Nhập tháng: ");
                int thang = int.Parse(Console.ReadLine());
                hpbd(danhb, thang); break;
            case 14:
                Console.Write("Nhập SDT: ");
                string sdt = Console.ReadLine();
                otp(danhb, sdt); break;            
        }
        goto kiet;
    }
    // 1.Danh sách quay số nhanh
    static void DBquaysonhanh(Dictionary<string, danhba> kiet, ref Dictionary<string, danhba> danhsach)
    {
        Console.WriteLine("So nguoi ban muon them vao danh sach la: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Nguoi muon them vao danh sach quay so nhanh theo thu tu uu tien:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Nguoi thu {0} : ", i + 1);
            string val = Console.ReadLine();
            danhba y = recusearch(kiet, 0, val);
            danhsach.Add((i + 1).ToString(), y);
        }
        Console.WriteLine("Danh sach quay so nhanh duoc tao");
        foreach (KeyValuePair<string, danhba> kt in danhsach)
        {
            Console.WriteLine(kt.Value);
        }
    }
    // 2.Tìm kiếm trong danh bạ
    static void Timkiemdanhba(Dictionary<string, danhba> kiet)
    {
        Console.WriteLine("Nhập địa điểm cần tìm kiếm");
        string val = Console.ReadLine();
        Console.WriteLine("Danh bạ người ở khu vực {0} là: ", val);
         foreach(KeyValuePair<string, danhba> kt in kiet){
             if(kt.Value.getnoio() == val){
                 Console.WriteLine(kt.Value);
            }
         }
    }
    // 3. Đổi thông tin trong danh bạ
    static void Doitt(Dictionary<string,danhba> kiet)
    {
        System.Console.WriteLine("Nhập tên người cần đổi thông tin: ");
        string value = Console.ReadLine();
        danhba kt = recusearch(kiet,0,value);
        System.Console.WriteLine("Thông tin ban đầu của {0} là {1}" ,value,kt.ToString());
        System.Console.WriteLine("Chọn thông tin cần chỉnh sửa:Tên(2); SĐT(3); Email(4); Facebook(5); Ngày sinh(6); Nơi ở(7)");
        int x = int.Parse(Console.ReadLine());
                switch(x){                  
                    case 2:
                    System.Console.Write("Tên mới: ");
                    string val2 = Console.ReadLine();
                    kiet[kt.getid()] = new danhba(kt.getid(), val2 ,kt.getsdt(),kt.getemail(),kt.getfb(), kt.getsinhnhat(),kt.getnoio(),kt.gettaikhoan());
                    break;
                    case 3:
                    System.Console.Write("SĐT mới: ");
                    string val3 = Console.ReadLine();
                    kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(),val3,kt.getemail(),kt.getfb(), kt.getsinhnhat(),kt.getnoio(), kt.gettaikhoan());
                    break;
                    case 4:
                    System.Console.Write("Email mới: ");
                    string val4 = Console.ReadLine();
                    kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(),kt.getsdt(),val4,kt.getfb(), kt.getsinhnhat(),kt.getnoio(), kt.gettaikhoan());
                    break;
                    case 5:
                    System.Console.Write("Facebook mới: ");
                    string val5 = Console.ReadLine();
                    kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(),kt.getsdt(),kt.getemail(),val5, kt.getsinhnhat(),kt.getnoio(), kt.gettaikhoan());
                    break;
                    case 6:
                    System.Console.Write("Ngày sinh mới: ");
                    string val6 = Console.ReadLine();
                    kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(),kt.getsdt(),kt.getemail(),kt.getfb(), val6,kt.getnoio(), kt.gettaikhoan());
                    break;
                    case 7:
                    System.Console.Write("Nơi ở mới: ");
                    string val7 = Console.ReadLine();
                    kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(),kt.getsdt(),kt.getemail(),kt.getfb(), kt.getsinhnhat(), val7, kt.gettaikhoan());
                    break;
                }
         System.Console.WriteLine("Thông tin mới là: " + kiet[kt.getid()].ToString());  
    }
    // 4. Xác định mạng di động đang sử dụng
    static void Mangdt(string value)
    {
        List<List<string>> mang = new List<List<string>>();
        List<string> Viettel = new List<string>();
        Viettel.Add("086");Viettel.Add("097");Viettel.Add("098");Viettel.Add("032");Viettel.Add("033");Viettel.Add("038");
        Viettel.Add("096");Viettel.Add("034");Viettel.Add("035");Viettel.Add("036");Viettel.Add("037");Viettel.Add("039");
        mang.Add(Viettel);
        List<string> Vinaphone = new List<string>();
        Vinaphone.Add("088");Vinaphone.Add("091");Vinaphone.Add("094");Vinaphone.Add("081");
        Vinaphone.Add("082");Vinaphone.Add("083");Vinaphone.Add("084");
        mang.Add(Vinaphone);
        List<string> Mobifone = new List<string>();
        Mobifone.Add("089");Mobifone.Add("090");Mobifone.Add("093");Mobifone.Add("070");Mobifone.Add("076");
        Mobifone.Add("077");Mobifone.Add("078");Mobifone.Add("079");
        mang.Add(Mobifone);
        List<string> Vietnamobile = new List<string>();
        Vietnamobile.Add("092");Vietnamobile.Add("056");Vietnamobile.Add("058");
        mang.Add(Vietnamobile);
        string value2 = value.Substring(0,3);
        string [] nhamang = {"Viettel", "Vinaphone","Mobifone","Vietnamobile"};
        for(int i = 0; i < mang.Count; i++){
            for(int j = 0; j < mang[i].Count;j++){
                if(value2 == mang[i][j]){
                    Console.WriteLine("Thuộc mạng {0}" , nhamang[i]);
                }
            }
        }
    }
    // 5. In thông tin trúng thưởng
    static void InTTtrungthuong(Dictionary<string, danhba> kiet, int sotrung)
    {
        Console.WriteLine("CON SỐ MAY MẮN CỦA CHƯƠNG TRÌNH LẦN NÀY LÀ : -{0}-",sotrung);
        danhba g = sensearch(kiet,sotrung.ToString());
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        Console.WriteLine("chuc mung ban {0} da trung giai !!!", g.getnhan());
        Console.WriteLine("Phân thưởng của bạn là một phần quà trị giá 100 triệu VND. Để có thể trao giải, chúng tôi cần bạn xác nhận thông tin của mình.");
        Console.WriteLine(g);
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        Console.WriteLine("Bạn hãy xác nhận những thông tin trên. Nếu đúng nhập (dung), nếu sai nhập (sai)");
        string nhap = Console.ReadLine();
        
        if (nhap == "dung")
        {
            Console.WriteLine("Cảm ơn bạn đã tham gia chương trình của chúng tôi!");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Tên {0}", g.getnhan());
            Console.WriteLine("Số điện thoại {0}", g.getsdt());
            Console.WriteLine("Email {0}", g.getemail());
            Console.WriteLine("Facebook {0}", g.getfb());
            Console.WriteLine("Ngày sinh{0}", g.getsinhnhat());
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
        else
        {
            string[] label = { "tên", "số điện thoại", "email", "facebook", "ngày sinh","nơi ở"};
            Console.WriteLine("Mời bạn nhập lại thông tin: ");
            List<string> nhaplai = new List<string>();
            for (int i = 0; i < label.Length; i++)
            {
                Console.Write("Nhập {0}: ", label[i]);
                nhaplai.Add(Console.ReadLine());
            }
            kiet[g.getid()] = new danhba(g.getid(), nhaplai[0], nhaplai[1], nhaplai[2], nhaplai[3], nhaplai[4],nhaplai[5],g.gettaikhoan());
            Console.WriteLine("Cảm ơn bạn đã tham gia chương trình của chúng tôi!");
        }
        
    }
    // 6. Tìm số điện thoại dựa theo số đầu
    static void timvaiso(Dictionary<string, danhba> kiet)
    {
        Console.Write("Nhập 4 số đầu của số điện thoại: ");
        string so = Console.ReadLine();
        int dodai = so.Length;
        for(int i = 0; i < kiet.Count; i++)
        {
            if(vitri(i,kiet).getsdt().Substring(0,dodai) == so)
            {
                Console.WriteLine("Danh sách các số có cùng {0} số {1} la: {2} ", dodai, so, vitri(i, kiet));
            }
        }
    }
    //7. Danh sách chặn
    static void chan(ref Dictionary<string, danhba> kiet,ref Dictionary<string, danhba> danhsachchan)
    {
                            
            for (int i = 0; i < kiet.Count; i++)
            {
                Console.WriteLine("Người {0}: {1}, Nhập ({2})", i + 1, vitri(i, kiet).getnhan(), i + 1);
            }
            Console.Write("Chọn người bạn muốn chặn: ");
            int y = int.Parse(Console.ReadLine());
            string v = seqsearch(kiet, (y - 1).ToString()).getid();              
            danhsachchan.Add(vitri(Convert.ToInt32(v), kiet).getid(), vitri(Convert.ToInt32(v), kiet));
            Console.WriteLine("Đã chặn thành công {0}", vitri(Convert.ToInt32(v), kiet).getnhan());
            kiet.Remove(vitri(Convert.ToInt32(v), kiet).getid());    
    }
    //8. Gỡ chặn
    static void gochan(ref Dictionary<string, danhba> kiet, ref Dictionary<string, danhba> danhsachchan)
    {
       
        
        Console.WriteLine("Nhập tên người bạn muốn gỡ chặn: ");
        string t = Console.ReadLine();
        danhba e =  seqsearch(danhsachchan, t);
        Console.WriteLine("Người bạn muốn gỡ chặn: {0}",e.ToString());
        Console.WriteLine("Mời bạn xác nhận việc gỡ chặn, ghi (GO) HOAC (KHONG):");
        string er = Console.ReadLine();
        if(er == "GO")
        {
            kiet[e.getid()] = danhsachchan[e.getid()];
            danhsachchan.Remove(e.getid());
        }
        else
        {
            Console.WriteLine("Lệnh gỡ chặn đã bị hủy");
        }
     
    }
    
    // 9. In ra các mục trong danh bạ
    static void inradanhba(Dictionary<string, danhba> kiet, Dictionary<string, danhba> kiet1, Dictionary<string, danhba> kiet2)
    {
        Console.WriteLine("Lựa chọn danh sách cần in: ");
        Console.WriteLine("DANH BẠ (1)");
        Console.WriteLine("DANH SÁCH CHẶN (2)");       
        Console.WriteLine("DANH SÁCH QUAY SỐ NHANH (3)");
        int tu = int.Parse(Console.ReadLine());
        switch (tu)
        {
            case 1:
                if (kiet.Count == 0)
                {
                    Console.WriteLine("Danh bạ trống");
                }
                foreach (KeyValuePair<string, danhba> t in kiet)
                {
                    Console.WriteLine(t.Value);
                }break;
            case 2:
                if (kiet1.Count == 0)
                {
                    Console.WriteLine("Danh sách chặn trống ");
                }
                foreach (KeyValuePair<string, danhba> t in kiet1)
                {
                    Console.WriteLine(t.Value);
                }
                break;
            case 3:
                if (kiet1.Count == 0)
                {
                    Console.WriteLine("Danh sách quay số nhanh trống ");
                }
                foreach (KeyValuePair<string, danhba> t in kiet2)
                {
                    Console.WriteLine(t.Value);
                }
                break;
        }
    }
    //10. Đếm số lượng trong danh bạ
    static int soluong(Dictionary<string, danhba> db)
    {
        int dem = 0;
        foreach (KeyValuePair<string, danhba> item in db)
            dem++;
        return dem;
    }
    //12. Chúc mừng sinh nhật
    static void hpbd(Dictionary<string, danhba> db, int thang)
    {
        for (int i = 0; i < soluong(db); i++)
        {
            string[] a = vitri(i, db).getsinhnhat().Split('/');
            if (Convert.ToInt16(a[1]) == thang)
            {
                Console.WriteLine("             *    *    *");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("             |    |    |");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("           xxxxxxxxxxxxxxx");
                // Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("           xxxxxxxxxxxxxxx");
                // Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("           xxxxxxxxxxxxxxx");
                // Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("     xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                //   Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("     xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                //  Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                //  Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.ForegroundColor = ConsoleColor.White;
                int tuoi = 2021 - Convert.ToInt16(a[2]);
                Console.WriteLine("CHÚC MỪNG SINH NHẬT LẦN THỨ {0} CỦA QUÝ KHÁCH {1}", tuoi, vitri(i, db).getsdt());
            }
        }
    }
    //14. Mã OTP
    static void otp(Dictionary<string, danhba> db, string sdt)
    {
        string otp = "";
        Random kiet = new Random();
        for (int i = 0; i < 6; i++)
        {
            int t = kiet.Next(0, 9);
            otp += t.ToString();
        }
        for (int i = 0; i < soluong(db); i++)
        {
            if (vitri(i, db).getsdt() == sdt)
            {
                Console.WriteLine("Mã OTP của quý khách là {0}, vui lòng không cung cấp OTP cho bất cứ ai ! ",otp);
            }
        }
    }
    // 10. 4 Hàm tìm kiếm 
    static danhba vitri(int so, Dictionary<string, danhba> kiet)
    {
        int dem = 0;
        foreach(KeyValuePair<string, danhba> ke in kiet)
        {
           if ( dem == so)
            {
                return ke.Value;
            }
           else
            {
                dem++;
            }
        }
        return new danhba("", "", "", "", "", "", "",0);
    }  
    static danhba seqsearch(Dictionary<string, danhba> danhb, string nhan)
    {

        foreach (KeyValuePair<string, danhba> t in danhb)
        {
            if (t.Value.getid().Contains(nhan) || t.Value.getnhan().Contains(nhan))
            {
                return t.Value;
            }
        }
        return new danhba("", "", "", "", "", "", "", 0);
    }
    static danhba recusearch(Dictionary<string, danhba> kiet, int f, string value)
    {
        if (f == kiet.Count)
        {
            return new danhba("", "", "", "", "", "", "", 0);
        }
        if( vitri(f,kiet).getid() == value || vitri(f,kiet).getnoio() == value || vitri(f,kiet).getnhan() == value)
        {
            return vitri(f, kiet);
        }

        return recusearch(kiet, f + 1, value);
    }
    static danhba sensearch(Dictionary<string, danhba> kiet, string value)
    {
        danhba x = vitri(kiet.Count - 1, kiet);
        kiet[vitri(kiet.Count - 1, kiet).getid()] = kiet[value];
        int i = 0;
        while (vitri(i,kiet).getid() != value) i++;
        kiet[x.getid()] = x;
        if (vitri(kiet.Count - 1, kiet).getid() == value || (i < kiet.Count - 1))
        {
            return vitri(i,kiet);
        }
        else
        {
            return new danhba("", "", "", "", "", "", "", 0);
        }
    }

    static danhba binsearch(Dictionary<string, danhba>hocsinh, string T)
    {
        int m, L, R;
        L = 0;
        R = hocsinh.Count - 1;
        while (L <= R)
        {
            m = (L + R) / 2;
            if (vitri(m, hocsinh).getid() == T)
            {
                return vitri(m,hocsinh);
            }
            else if (Convert.ToInt32(vitri(m, hocsinh).getid()) < Convert.ToInt32(T))
            {
                L = m + 1;
            }
            else
            {
                R = m - 1;
            }
        }
        return new danhba("", "", "", "", "", "", "", 0);

    }

    static void xoa( Dictionary<string, danhba>kiet, string id){
        danhba sotim = seqsearch(kiet, id);
        kiet.Remove(sotim.getid());
    }
    class danhba
    {
        private string id;
        private string nhan;
        private string sdt;
        private string email;
        private string fb;
        private string sinhnhat;
        private string noio;
        private int taikhoan;

        public string getid()
        {
            return this.id;
        }
        public string getnhan()
        {
            return this.nhan;
        }
        public string getsdt()
        {
            return this.sdt;
        }
        public string getemail()
        {
            return this.email;
        }
        public string getfb()
        {
            return this.fb;
        }
        public string getsinhnhat()
        {
            return this.sinhnhat;
        }
        public string getnoio()
        {
            return this.noio;
        }
        public int gettaikhoan()
        {
            return this.taikhoan;
        }

        public danhba(string id, string nhan, string sdt, string email, string fb, string sinhnhat, string noio, int taikhoan)
        {
            this.id = id;
            this.nhan = nhan;
            this.sdt = sdt;
            this.email = email;
            this.fb = fb;
            this.sinhnhat = sinhnhat;
            this.noio = noio;
            this.taikhoan = taikhoan;


        }
        public override string ToString()
        {
            return "(" + id + "," + nhan + "," + sdt + "," + email + "," + fb + "," + sinhnhat + "," + noio + ".)";
        }
    }
}