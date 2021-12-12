using System;
using System.Collections.Generic;
using System.Collections;
class program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Dictionary<string, danhba> danhb = new Dictionary<string, danhba>();
        Dictionary<string, danhba> danhsachchan = new Dictionary<string, danhba>();
        Dictionary<string, danhba> danhsach = new Dictionary<string, danhba>();
        danhb.Add("1", new danhba("1", "VTK", "0906889483", "hungsamgnuyen@gmail.com", "vantuankiet", "22/07/2002", "TP HCM", 30000));
        danhb.Add("2", new danhba("2", "NTH", "0909678860", "taolanhat2200@gmail.com", "nongthaohien", "15/03/2002", "TG", 50000));
        danhb.Add("3", new danhba("3", "DTPA", "0827265337", "anhdo20@gmail.com", "dophuonganh", "28/03/2002", "TH", 125000));
        danhb.Add("4", new danhba("4", "PTNQ", "0967265347", "quynh04@gmail.com", "phannhuquynh", "08/11/2002", "NA", 170300));
        danhb.Add("5", new danhba("5", "NVN", "0907265367", "ninhnguyen77@gmail.com", "nguyenvanninh", "22/05/1975", "TP HCM", 90000));
        danhb.Add("6", new danhba("6", "MS", "0926472453", "sieuma@gmail.com", "MaSieu", "04/11/2002", "NA", 200000));
        danhb.Add("7", new danhba("7", "BTV", "0832561579", "vanbui22@gmail.com", "vanbui", "16/09/1999", "TP HCM", 50000));
        danhb.Add("8", new danhba("8", "SAH", "0947265337", "anhhung24680@gmail.com", "anhhungrom", "28/3/2007", "QB", 10000000));
        danhb.Add("9", new danhba("9", "DHY", "0867265347", "quynh04@gmail.com", "hoangyen", "29/04/1998", "TG", 1700000));
        danhb.Add("10", new danhba("10", "TTH", "0927265367", "thanhhatang00@gmail.com", "tangthanhha", "13/08/2000", "TP HCM", 900000));
    tim:
        Console.WriteLine("GIAO DIỆN");
        Console.WriteLine(">> SỰ KIỆN (1)");
        Console.WriteLine(">> CÔNG CỤ (2)");
        Console.WriteLine(">> IN RA DANH BẠ (3)");
        Console.Write("Chọn giao diện bạn muốn thực hiện: ");
        int nhap = int.Parse(Console.ReadLine());
        switch (nhap)
        {
            case 1:
                Console.WriteLine(">> SỰ KIỆN ");
                Console.WriteLine("> Sự kiện trúng thưởng (1)");
                Console.WriteLine("> Sự kiện sinh nhật (2)");
                Console.Write("Chọn chức năng bạn muốn thực hiện: ");
                int nhap1 = int.Parse(Console.ReadLine());
                switch (nhap1)
                {
                    case 1:
                        Random so = new Random();
                        int ngaunhien = so.Next(1, danhb.Count);
                        InTTtrungthuong(danhb, ngaunhien);
                        break;
                    case 2:
                        Console.Write("Nhập tháng: ");
                        int thang = int.Parse(Console.ReadLine());
                        hpbd(danhb, thang); break;
                }
                break;
            case 2:
                Console.WriteLine(">> CÔNG CỤ ");
                Console.WriteLine("> Danh sách quay số nhanh (1)");
                Console.WriteLine("> Tìm kiếm trong danh bạ (2)");
                Console.WriteLine("> Đổi thông tin người dùng trong danh bạ (3)");
                Console.WriteLine("> Tìm số điện thoại dựa theo vài số đầu (4)");
                Console.WriteLine("> Chặn người dùng (5)");
                Console.WriteLine("> Gỡ chặn người dùng (6)");
                Console.WriteLine("> Mạng di động (7)");
                Console.WriteLine("> Nạp tiền điện thoại và chuyển khoản (8)");
                Console.WriteLine("> Gửi mã OTP (9)");
                Console.WriteLine("> Xóa (10)");
                Console.WriteLine("> Thêm người dùng (11)");
                Console.WriteLine("");
                Console.WriteLine("Chọn chức năng bạn muốn thực hiện: ");
                int nhap2 = int.Parse(Console.ReadLine());
                switch (nhap2)
                {
                    case 1:
                        DBquaysonhanh(danhb, ref danhsach); break;
                    case 2:
                        Timkiemdanhba(danhb); break;
                    case 3:
                        Doitt(danhb); break;
                    case 4:
                        timvaiso(danhb); break;
                    case 5:
                        chan(ref danhb, ref danhsachchan); break;
                    case 6:
                        gochan(ref danhb, ref danhsachchan); break;
                    case 7:
                        foreach (KeyValuePair<string, danhba> kt in danhb)
                        {
                            Console.Write("SĐT của {0} ", kt.Value.getnhan());
                            Mangdt(kt.Value.getsdt());
                        }
                        break;
                    case 8:
                        Naptien(ref danhb); break;
                    case 9:
                        Console.Write("Nhập SĐT: ");
                        string sdt = Console.ReadLine();
                        otp(danhb, sdt); break;
                    case 10:
                        Console.WriteLine("Nhập SĐT cần xóa: ");
                        string dt = Console.ReadLine();
                        xoa(danhb, dt); break;
                    case 11:
                        Console.WriteLine("Nhập dữ liệu người cần thêm: ");
                        AddStudent(danhb); break;
                }
                break;
            case 3:

                inradanhba(danhb, danhsachchan, danhsach); break;
        }
        goto tim;
    }
    // 1.Danh sách quay số nhanh
    static void DBquaysonhanh(Dictionary<string, danhba> kiet, ref Dictionary<string, danhba> danhsach)
    {
        Console.WriteLine("Số người bạn muốn thêm vào danh sách là: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Người muốn thêm vào danh sách quay số nhanh theo thứ tự ưu tiên:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Người thứ {0} : ", i + 1);
            string val = Console.ReadLine();
            danhba y = recusearch(kiet, 0, val);
            danhsach.Add((i + 1).ToString(), y);
        }
        Console.WriteLine("Danh sách quay số nhanh được tạo");
        foreach (KeyValuePair<string, danhba> kt in danhsach)
        {
            Console.WriteLine("Key = {0} ; Value = {1}. ", kt.Key, kt.Value);
        }
    }
    // 2.Tìm kiếm trong danh bạ
    static void Timkiemdanhba(Dictionary<string, danhba> kiet)
    {

        Console.WriteLine("Nhập địa điểm cần tìm kiếm");
        string val = Console.ReadLine();
        Console.WriteLine("Danh bạ người ở khu vực {0} là: ", val);
        foreach (KeyValuePair<string, danhba> kt in kiet)
        {
            if (kt.Value.getnoio() == val)
            {
                Console.WriteLine(kt.Value);
            }
        }
    }
    // 3. Đổi thông tin trong danh bạ
    static void Doitt(Dictionary<string, danhba> kiet)
    {
        System.Console.WriteLine("Nhập số điện thoại cần đổi thông tin: ");
        string value = Console.ReadLine();
        danhba kt = recusearch(kiet, 0, value);
        System.Console.WriteLine("Thông tin ban đầu của {0} là {1}", value, kt.ToString());
        System.Console.WriteLine("Chọn thông tin cần chỉnh sửa: Tên(2); Email(4); Facebook(5); Ngày sinh(6); Nơi ở(7)");
        int x = int.Parse(Console.ReadLine());
        switch (x)
        {
            case 2:
                System.Console.Write("Tên mới: ");
                string val2 = Console.ReadLine();
                kiet[kt.getid()] = new danhba(kt.getid(), val2, kt.getsdt(), kt.getemail(), kt.getfb(), kt.getsinhnhat(), kt.getnoio(), kt.gettaikhoan());
                break;
            case 4:
                System.Console.Write("Email mới: ");
                string val4 = Console.ReadLine();
                kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(), kt.getsdt(), val4, kt.getfb(), kt.getsinhnhat(), kt.getnoio(), kt.gettaikhoan());
                break;
            case 5:
                System.Console.Write("Facebook mới: ");
                string val5 = Console.ReadLine();
                kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(), kt.getsdt(), kt.getemail(), val5, kt.getsinhnhat(), kt.getnoio(), kt.gettaikhoan());
                break;
            case 6:
                System.Console.Write("Ngày sinh mới: ");
                string val6 = Console.ReadLine();
                kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(), kt.getsdt(), kt.getemail(), kt.getfb(), val6, kt.getnoio(), kt.gettaikhoan());
                break;
            case 7:
                System.Console.Write("Nơi ở mới: ");
                string val7 = Console.ReadLine();
                kiet[kt.getid()] = new danhba(kt.getid(), kt.getnhan(), kt.getsdt(), kt.getemail(), kt.getfb(), kt.getsinhnhat(), val7, kt.gettaikhoan());
                break;
        }
        System.Console.WriteLine("Thông tin mới là: " + kiet[kt.getid()].ToString());
    }
    // 4. Xác định mạng di động đang sử dụng
    static void Mangdt(string value)
    {
        List<List<string>> mang = new List<List<string>>();
        List<string> Viettel = new List<string>();
        Viettel.Add("086"); Viettel.Add("097"); Viettel.Add("098"); Viettel.Add("032"); Viettel.Add("033"); Viettel.Add("038");
        Viettel.Add("096"); Viettel.Add("034"); Viettel.Add("035"); Viettel.Add("036"); Viettel.Add("037"); Viettel.Add("039");
        mang.Add(Viettel);
        List<string> Vinaphone = new List<string>();
        Vinaphone.Add("088"); Vinaphone.Add("091"); Vinaphone.Add("094"); Vinaphone.Add("081");
        Vinaphone.Add("082"); Vinaphone.Add("083"); Vinaphone.Add("084");
        mang.Add(Vinaphone);
        List<string> Mobifone = new List<string>();
        Mobifone.Add("089"); Mobifone.Add("090"); Mobifone.Add("093"); Mobifone.Add("070"); Mobifone.Add("076");
        Mobifone.Add("077"); Mobifone.Add("078"); Mobifone.Add("079");
        mang.Add(Mobifone);
        List<string> Vietnamobile = new List<string>();
        Vietnamobile.Add("092"); Vietnamobile.Add("056"); Vietnamobile.Add("058");
        mang.Add(Vietnamobile);
        string value2 = value.Substring(0, 3);
        string[] nhamang = { "Viettel", "Vinaphone", "Mobifone", "Vietnamobile" };
        for (int i = 0; i < mang.Count; i++)
        {
            for (int j = 0; j < mang[i].Count; j++)
            {
                if (value2 == mang[i][j])
                {
                    Console.WriteLine("Thuộc mạng {0}", nhamang[i]);
                }
            }
        }
    }
    // 5. In thông tin trúng thưởng
    static void InTTtrungthuong(Dictionary<string, danhba> kiet, int sotrung)
    {
        Console.WriteLine("CON SỐ MAY MẮN CỦA CHƯƠNG TRÌNH LẦN NÀY LÀ : -{0}-", sotrung);
        danhba g = binsearch(kiet, sotrung.ToString());
        Console.WriteLine(" =======================================================");
        Console.WriteLine("Chúc mừng bạn {0} đã trúng giải!!!", g.getnhan());
        Console.WriteLine("Phần thưởng của bạn là một phần quà trị giá 100 triệu VND. Để có thể trao giải, chúng tôi cần bạn xác nhận thông tin của mình.");
        Console.WriteLine(g);
        Console.WriteLine("=========================================================");
        Console.WriteLine("Bạn hãy xác nhận những thông tin trên. Nếu đúng nhập (dung), nếu sai nhập phím bất kỳ");
        string nhap = Console.ReadLine();
        if (nhap.ToLower() == "dung")
        {
            Console.WriteLine(" =======================================================");
            Console.WriteLine("Tên: {0}", g.getnhan());
            Console.WriteLine("Số điện thoại: {0}", g.getsdt());
            Console.WriteLine("Email: {0}", g.getemail());
            Console.WriteLine("Facebook: {0}", g.getfb());
            Console.WriteLine("Ngày sinh: {0}", g.getsinhnhat());
            Console.WriteLine("Nơi ở {0}", g.getnoio());
            Console.WriteLine(" =======================================================");
            Console.WriteLine("Cảm ơn bạn đã tham gia chương trình của chúng tôi!");
        }
        else
        {
            Console.WriteLine("Bạn hãy chỉnh sửa thông tin của mình: ");
            Doitt(kiet);
            danhba l = binsearch(kiet, sotrung.ToString());
            Console.WriteLine(" =======================================================");
            Console.WriteLine("Tên: {0}", l.getnhan());
            Console.WriteLine("Số điện thoại: {0}", l.getsdt());
            Console.WriteLine("Email: {0}", l.getemail());
            Console.WriteLine("Facebook: {0}", l.getfb());
            Console.WriteLine("Ngày sinh: {0}", l.getsinhnhat());
            Console.WriteLine("Nơi ở {0}", l.getnoio());
            Console.WriteLine(" =======================================================");
            Console.WriteLine("Cảm ơn bạn đã tham gia chương trình của chúng tôi!");
        }

    }
    // 6. Tìm số điện thoại dựa theo số đầu
    static void timvaiso(Dictionary<string, danhba> kiet)
    {
        Console.Write("Nhập 4 số đầu của số điện thoại: ");
        string so = Console.ReadLine();
        int dodai = so.Length;
        for (int i = 0; i < kiet.Count; i++)
        {
            if (vitri(i, kiet).getsdt().Substring(0, dodai) == so)
            {
                Console.WriteLine("Danh sách các số có cùng {0} số {1} là: {2} ", dodai, so, vitri(i, kiet));
            }
        }
    }
    //7. Danh sách chặn
    static void chan(ref Dictionary<string, danhba> kiet, ref Dictionary<string, danhba> danhsachchan)
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
        danhba e = seqsearch(danhsachchan, t);
        Console.WriteLine("Người bạn muốn gỡ chặn: {0}", e.ToString());
        Console.WriteLine("Mời bạn xác nhận việc gỡ chặn, ghi (GO) hoặc (KHONG):");
        string er = Console.ReadLine();
        if (er == "GO")
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
        Console.WriteLine("Lựa chọn danh bạ bạn  cần in: ");
        Console.WriteLine("DANH BẠ (1)");
        Console.WriteLine("DANH SÁCH CHẶN (2)");
        Console.WriteLine("DANH SÁCH QUAY SỐ NHANH (3)");
        Console.WriteLine("TÀI KHOẢN DANH BẠ (4)");
        int tu = int.Parse(Console.ReadLine());
        switch (tu)
        {
            case 1:
                if (kiet.Count == 0)
                {
                    Console.WriteLine("Danh bạ trống");
                }
                Console.WriteLine("Danh bạ có {0} người", soluong(kiet));
                Console.WriteLine("Danh bạ : ");
                foreach (KeyValuePair<string, danhba> t in kiet)
                {
                    Console.WriteLine(t.Value);
                }
                break;
            case 2:
                if (kiet1.Count == 0)
                {
                    Console.WriteLine("Danh sách chặn trống ");
                }
                Console.WriteLine("Danh sách chặn có {0} người", soluong(kiet1));
                Console.WriteLine("Danh sách chặn : ");
                foreach (KeyValuePair<string, danhba> t in kiet1)
                {
                    Console.WriteLine(t.Value);
                }
                break;
            case 3:
                if (kiet2.Count == 0)
                {
                    Console.WriteLine("Danh sách quay số nhanh trống ");
                }
                Console.WriteLine("Danh sách quay số nhanh có {0} người", soluong(kiet2));
                Console.WriteLine("Danh sách quay số nhanh : ");
                foreach (KeyValuePair<string, danhba> t in kiet2)
                {
                    Console.WriteLine(t.Value);
                }
                break;
            case 4:
                Console.WriteLine("Tài khoản người dùng trong danh bạ: ");
                foreach (KeyValuePair<string, danhba> wu in kiet)
                {
                    Console.WriteLine("{0} ({1}): {2}", wu.Value.getnhan(), wu.Value.getsdt(), wu.Value.gettaikhoan());
                }
                break;
        }
    }
    //10. Đếm số lượng trong danh bạ
    static int soluong(Dictionary<string, danhba> hien)
    {
        int dem = 0;
        foreach (KeyValuePair<string, danhba> item in hien)
            dem++;
        return dem;
    }
    // 11. Nạp tiền vào sđt
    static void Naptien(ref Dictionary<string, danhba> kiet)
    {
        Console.WriteLine("SĐT của bạn là: ");
        string so = Console.ReadLine();
        danhba k = seqsearch(kiet, so);
        Console.WriteLine("Bạn muốn nạp tiền hay nạp chuyển tiền từ tài khoản : Nạp tiền (1) ; Chuyển tiền (2)");
        int x = int.Parse(Console.ReadLine());
        if (x == 1)
        {
            Console.WriteLine("Nhập số tiền bạn cần nạp là: ");
            int tien = int.Parse(Console.ReadLine());
            danhba qu = new danhba(k.getid(), k.getnhan(), k.getsdt(), k.getemail(), k.getfb(), k.getsinhnhat(), k.getnoio(), k.gettaikhoan() + tien);
            kiet.Remove(k.getid());
            kiet.Add(k.getid(), qu);
            Console.WriteLine("Tài khoản {0} hiện có {1} đồng sau khi được nạp.", so, qu.gettaikhoan());
        }
        else
        {
            Console.WriteLine("Nhập số tiền bạn cần nạp là: ");
            int tien1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Tài khoản bạn muỗn chuyển là: ");
            string sodt = Console.ReadLine();
            danhba h = seqsearch(kiet, sodt);
            danhba q = new danhba(k.getid(), k.getnhan(), k.getsdt(), k.getemail(), k.getfb(), k.getsinhnhat(), k.getnoio(), k.gettaikhoan() - tien1);
            kiet.Remove(k.getid());
            kiet.Add(k.getid(), q);
            danhba j = new danhba(h.getid(), h.getnhan(), h.getsdt(), h.getemail(), h.getfb(), h.getsinhnhat(), h.getnoio(), h.gettaikhoan() + tien1);
            kiet.Remove(h.getid());
            kiet.Add(h.getid(), j);
            Console.WriteLine("Tài khoản {0} hiện có {1} đồng sau khi chuyển tiền.", so, q.gettaikhoan());
            Console.WriteLine("Tài khoản {0} hiện có {1} đồng sau khi được nạp.", sodt, j.gettaikhoan());
        }
    }
    //12. Chúc mừng sinh nhật
    static void hpbd(Dictionary<string, danhba> hien, int thang)
    {
        for (int i = 0; i < soluong(hien); i++)
        {
            string[] a = vitri(i, hien).getsinhnhat().Split('/');
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
                Console.WriteLine("CHÚC MỪNG SINH NHẬT LẦN THỨ {0} CỦA QUÝ KHÁCH {1}", tuoi, vitri(i, hien).getsdt());
            }
            else Console.WriteLine("KHÔNG CÓ QUÝ KHÁCH SINH THÁNG {0}.", thang);
        }
    }
    //13. Mã OTP
    static void otp(Dictionary<string, danhba> hien, string sdt)
    {
        string otp = "";
        Random kiet = new Random();
        for (int i = 0; i < 6; i++)
        {
            int t = kiet.Next(0, 9);
            otp += t.ToString();
        }
        for (int i = 0; i < soluong(hien); i++)
        {
            if (vitri(i, hien).getsdt() == sdt)
            {
                Console.WriteLine("Mã OTP của quý khách là {0} , vui lòng không cung cấp OTP cho bất cứ ai ! ", otp);
            }
        }
    }
    //15.Xóa
    static void xoa(Dictionary<string, danhba> kiet, string id)
    {
        danhba sotim = seqsearch(kiet, id);
        kiet.Remove(sotim.getid());
    }
    //16. Add
    static void AddStudent(Dictionary<string, danhba> kiet)
    {
        string[] label = { "tên", "SĐT", "Email", "FB", "Ngày sinh", "Nơi ở" };
        List<string> nhap = new List<string>();
        for (int i = 0; i < label.Length; i++)
        {
            Console.Write("Nhập {0}: ", label[i]);
            nhap.Add(Console.ReadLine());
        }
        int id = soluong(kiet) + 1;
        danhba tamthoi = new danhba(id.ToString(), nhap[0], nhap[1], nhap[2], nhap[3], nhap[4], nhap[5], 0);
        foreach (KeyValuePair<string, danhba> at in kiet)
        {
            if (at.Value.getnhan().Equals(tamthoi.getnhan()))
            {
                Console.Write("Tên đã bị trùng, vui lòng nhập tên mới: ");
                string tenmoi = Console.ReadLine();
                kiet.Add(id.ToString(), new danhba(id.ToString(), tenmoi, nhap[1], nhap[2], nhap[3], nhap[4], nhap[5], 0));
            }
            if (at.Value.getsdt().Equals(tamthoi.getsdt()))
            {
                Console.Write("SĐT đã bị trùng, vui lòng nhập SĐT mới: ");
                string sdtmoi = Console.ReadLine();
                kiet.Add(id.ToString(), new danhba(id.ToString(), nhap[0], sdtmoi, nhap[2], nhap[3], nhap[4], nhap[5], 0));
            }
            break;
        }
        kiet.Add(id.ToString(), tamthoi);
    }
    // 17.. 4 Hàm tìm kiếm 
    static danhba vitri(int so, Dictionary<string, danhba> kiet)
    {
        int dem = 0;
        foreach (KeyValuePair<string, danhba> ke in kiet)
        {
            if (dem == so)
            {
                return ke.Value;
            }
            else
            {
                dem++;
            }
        }
        return new danhba("", "", "", "", "", "", "", 0);
    }
    static danhba seqsearch(Dictionary<string, danhba> danhb, string nhan)
    {
        foreach (KeyValuePair<string, danhba> t in danhb)
        {
            if (t.Value.getid().Contains(nhan) || t.Value.getnhan().Contains(nhan) || t.Value.getsdt().Contains(nhan))
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
        if (vitri(f, kiet).getid() == value || vitri(f, kiet).getnoio() == value || vitri(f, kiet).getnhan() == value || vitri(f, kiet).getsdt() == value)
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
        while (vitri(i, kiet).getid() != value) i++;
        kiet[x.getid()] = x;
        if (vitri(kiet.Count - 1, kiet).getid() == value || (i < kiet.Count - 1))
        {
            return vitri(i, kiet);
        }
        else
        {
            return new danhba("", "", "", "", "", "", "", 0);
        }
    }
    static danhba binsearch(Dictionary<string, danhba> hocsinh, string T)
    {
        int m, L, R;
        L = 0;
        R = hocsinh.Count - 1;
        while (L <= R)
        {
            m = (L + R) / 2;
            if (vitri(m, hocsinh).getid() == T)
            {
                return vitri(m, hocsinh);
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