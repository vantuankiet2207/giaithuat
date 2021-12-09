using System;
using System.Collections.Generic;
using System.Collections;
class program
{
    static void Main(string[] args)
    {
       Dictionary<string, danhba> danhb = new Dictionary<string, danhba>();
        Dictionary<string, danhba> thanthiet = new Dictionary<string, danhba>();
        Dictionary<string, danhba> danhsachchan = new Dictionary<string, danhba>();
        
        danhb.Add("1", new danhba("1", "VTK", "0906889483", "hungsamgnuyen", "vantuankiet", "22/07/2002","TP HCM"));
        danhb.Add("2", new danhba("2", "VTT", "0909678860", "taolanhat2200", "vantuquyen", "2/1/2002", "TP HCM"));
        danhb.Add("3", new danhba("3", "kieotCK", "0907265337", "funfun1234", "lamquocnhan", "22/5/2002", "TP HCM"));
        danhb.Add("4", new danhba("4", "CK", "0907265337", "funfun1234", "lamquocnhan", "22/5/2002", "TP HCM"));
        danhb.Add("5", new danhba("5", "444CK", "0907265337", "funfun1234", "lamquocnhan", "22/5/2002", "TP HCM"));
        
        Random so = new Random();
        int ngaunhien = so.Next(1, 5);
        // bai 1
         InTTtrungthuong(danhb, ngaunhien);
        foreach(KeyValuePair<string, danhba> kr in danhb)
        {
            Console.WriteLine(kr.Value);
        }
        // bai 2
        string hehe = "";
      //   timvaiso(danhb, ref hehe);
        // bai 3
        Dictionary<string, danhba> danhsachchan = new Dictionary<string, danhba>();
        chan(ref danhb, ref danhsachchan);
        foreach (KeyValuePair<string, danhba> kr in danhb)
        {
            Console.WriteLine(kr.Value);
        }
        gochan(ref danhb, ref danhsachchan);
        foreach (KeyValuePair<string, danhba> kr in danhb)
        {
            Console.WriteLine(kr.Value);
        }
        inradanhba(danhb, danhsachchan, thanthiet);
        catnhatkhanhhangthanthiet(danhb, ref thanthiet);
    }
    // tinh nang cho dic
    static void InTTtrungthuong(Dictionary<string, danhba> kiet, int sotrung)
    {
        danhba g = sensearch(kiet,sotrung.ToString());
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        Console.WriteLine("chuc mung ban {0} da trung giai !!!", g.getnhan());
        Console.WriteLine("phan thuong cua ban la mot so tien tri gia 100tr dong. De co the trao giai chung toi can ban xac nhan thong tin cua ban de co the trao giai");
        Console.WriteLine(g);
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        Console.WriteLine("ban hay xac nhan nhung thong tin tren. Neu dung nhap(dung), new sai nhap (sai)");
        string nhap = Console.ReadLine();
        
        if (nhap == "dung")
        {
            Console.WriteLine("chung toi da nhan duoc xac nhan cua ban, cam on ban da tham gia chuong trinh cua chung toi!");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("ten {0}", g.getnhan());
            Console.WriteLine("so dien thoai {0}", g.getsdt());
            Console.WriteLine("dia chi email {0}", g.getemail());
            Console.WriteLine("facebook {0}", g.getfb());
            Console.WriteLine("ngay sinh{0}", g.getsinhnhat());
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
        else
        {
            string[] label = { "ten", "so dien thoai", "email", "facebook", "ngay sinh","noi o"};
            Console.WriteLine("chung toi gui ban form dien lai, moi ban nhap lai thong tin chinh xac");
            List<string> nhaplai = new List<string>();
            for (int i = 0; i < label.Length; i++)
            {
                Console.Write("nhap {0}: ", label[i]);
                nhaplai.Add(Console.ReadLine());
            }
            kiet[g.getid()] = new danhba(g.getid(), nhaplai[0], nhaplai[1], nhaplai[2], nhaplai[3], nhaplai[4],nhaplai[5]);
            Console.WriteLine("chung toi da nhan duoc xac nhan cua ban, cam on ban da tham gia chuong trinh cua chung toi!");
        }
        
    }
    static void timvaiso(Dictionary<string, danhba> kiet, ref string so)
    {
        Console.Write("nhap vao 4 so dau cua dien thoai: ");
        so = Console.ReadLine();
        int dodai = so.Length;
        for(int i = 0; i < kiet.Count; i++)
        {
            if(vitri(i,kiet).getsdt().Substring(0,dodai) == so)
            {
                Console.WriteLine("list cac so co cung {0} so {1} la: {2} ", dodai, so, vitri(i, kiet));
            }
        }
    }
    static void chan(ref Dictionary<string, danhba> kiet,ref Dictionary<string, danhba> danhsachchan)
    {
                            
            for (int i = 0; i < kiet.Count; i++)
            {
                Console.WriteLine("nguoi {0}: {1}, nhap ({2})", i + 1, vitri(i, kiet).getnhan(), i + 1);
            }
            Console.Write("chon nguoi ban muon chan: ");
            int y = int.Parse(Console.ReadLine());
            string v = seqsearch(kiet, (y - 1).ToString()).getid();              
            danhsachchan.Add(vitri(Convert.ToInt32(v), kiet).getid(), vitri(Convert.ToInt32(v), kiet));
            Console.WriteLine("da chan thanh cong {0}", vitri(Convert.ToInt32(v), kiet).getnhan());
            kiet.Remove(vitri(Convert.ToInt32(v), kiet).getid());    
    }
    static void gochan(ref Dictionary<string, danhba> kiet, ref Dictionary<string, danhba> danhsachchan)
    {
        Console.WriteLine(danhsachchan.Count);
        Console.WriteLine("chon ra nguoi can go chan: ");
        string t = Console.ReadLine();
        for (int i = 0; i < danhsachchan.Count; i++)
        {
            Console.WriteLine("({0}) {1}", vitri(i, danhsachchan).getid(), vitri(i, danhsachchan));
        }
        kiet[t] = danhsachchan[t];
    }
    static void inradanhba(Dictionary<string, danhba> kiet, Dictionary<string, danhba> kiet1, Dictionary<string, danhba> kiet2)
    {
        Console.WriteLine("Lua chon danh sach can in ra: ");
        Console.WriteLine("DANH SACH DANH BA TONG (1)");
        Console.WriteLine("DANH SACH CHAN (2)");
        Console.WriteLine("DANH SACH KHACH HANG THAN THIET (3)");
        int tu = int.Parse(Console.ReadLine());
        switch (tu)
        {
            case 1:
                if (kiet.Count == 0)
                {
                    Console.WriteLine("khong co nguoi nao trong danh ba tong");
                }
                foreach (KeyValuePair<string, danhba> t in kiet)
                {
                    Console.WriteLine(t.Value);
                }break;
            case 2:
                if (kiet1.Count == 0)
                {
                    Console.WriteLine("khong co nguoi nao trong danh sach chan");
                }
                foreach (KeyValuePair<string, danhba> t in kiet1)
                {
                    Console.WriteLine(t.Value);
                }
                break;
            case 3:
                if (kiet2.Count == 0)
                {
                    Console.WriteLine("khong co nguoi nao trong danh sach than thiet");
                }
                foreach (KeyValuePair<string, danhba> t in kiet2)
                {
                    Console.WriteLine(t.Value);
                }
                break;
        }
    }
    static void catnhatkhanhhangthanthiet(Dictionary<string, danhba> danhb,ref Dictionary<string, danhba> kiet)
    {
        for (int i = 0; i < kiet.Count; i++)
        {
            Console.WriteLine("nguoi {0}: {1}, nhap ({2})", i + 1, vitri(i, kiet).getnhan(), i + 1);
        }
        Console.WriteLine("CAC MOC THAN THIET:");
        Console.WriteLine("VANG (so tien trong tai khoan > 150000");
        Console.WriteLine("BAC (so tien trong tai khoan > 100000");
        Console.WriteLine("DONG (so tien trong tai khoan < 100000");
        foreach(KeyValuePair<string, danhba> kt in danhb)
        {
            if(kt.Value.gettaikhoan() > 150000) kiet.Add(kt.Value.getid(), kt.Value);
            else if (kt.Value.gettaikhoan() > 100000) kiet.Add(kt.Value.getid(), kt.Value);
            else  kiet.Add(kt.Value.getid(), kt.Value);
        }
        Console.WriteLine("DA CAT NHAT THANHG CONG !");

       
    }
    // 4 ham tim kiem
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
        return new danhba("", "", "", "", "", "", "");
    }  
    static danhba seqsearch(Dictionary<string, danhba> danhb, string nhan)
    {

        foreach (KeyValuePair<string, danhba> t in danhb)
        {
            if (t.Value.getid().Contains(nhan))
            {
                return t.Value;
            }
        }
        return new danhba("", "", "", "", "", "", "");
    }
    static danhba recusearch(Dictionary<string, danhba> kiet, int f, string value)
    {
        if (f == kiet.Count)
        {
            return new danhba("", "", "", "", "", "", "");
        }
        if( vitri(f,kiet).getid() == value)
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
            return new danhba("", "", "", "", "", "",""); 
        }
    }

    static danhba bitsearch(Dictionary<string, danhba>hocsinh, string T)
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
        return new danhba("", "", "", "", "", "","");

    }

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

    public danhba(string id, string nhan, string sdt, string email, string fb, string sinhnhat,string noio)
    {
        this.id = id;
        this.nhan = nhan;
        this.sdt = sdt;
        this.email = email;
        this.fb = fb;
        this.sinhnhat = sinhnhat;
        this.noio = noio;
        
    }
    public override string ToString()
    {
        return "(" + id + "," + nhan + "," + sdt + "," + email + "," + fb + "," + sinhnhat + ","+ noio +".)";
    }
}
