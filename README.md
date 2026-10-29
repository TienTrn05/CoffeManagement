# Coffee Shop Management

Ứng dụng desktop quản lý quán cà phê được xây dựng bằng **C# Windows Forms**, **.NET Framework 4.7.2**, **Entity Framework 6** và **SQL Server**. Dự án hỗ trợ quy trình phục vụ tại quán: chọn bàn, gọi món, điều chỉnh số lượng, chuyển bàn và thanh toán; đồng thời cung cấp các màn hình quản lý thực đơn, tài khoản và hóa đơn.

> A Windows desktop application for coffee shop operations, including table-based ordering, discounted checkout, menu management, and admin/staff access.

## Chức năng

- **Đăng nhập và tài khoản:** đăng nhập bằng tên người dùng/mật khẩu, cập nhật tên hiển thị và đổi mật khẩu. Menu quản lý chỉ được bật cho tài khoản `Admin`.
- **Quản lý bàn:** thêm, sửa, xóa bàn; hiển thị trạng thái `Trống` / `Có người`; chuyển món từ bàn hiện tại sang bàn đích.
- **Gọi món:** chọn đồ uống theo danh mục, thêm món và điều chỉnh số lượng trong hóa đơn của từng bàn.
- **Thanh toán:** tính tổng tiền, áp dụng giảm giá theo phần trăm, lưu thông tin thanh toán và cập nhật trạng thái bàn.
- **Quản lý thực đơn:** thêm, sửa, xóa đồ uống và danh mục; tìm kiếm tên sau khi chuẩn hóa dấu Unicode và chữ hoa/thường.
- **Quản lý tài khoản:** tạo, chỉnh sửa, xóa tài khoản với vai trò `Admin` hoặc `Staff`; chặn xóa tài khoản đang đăng nhập.
- **Tra cứu hóa đơn:** xem thông tin hóa đơn và phân trang 10 hóa đơn/trang.

## Công nghệ

| Thành phần | Công nghệ |
| --- | --- |
| Ngôn ngữ | C# |
| Nền tảng | .NET Framework 4.7.2, Windows Forms |
| Giao diện | Guna.UI2.WinForms 2.0.4.7 |
| Truy cập dữ liệu | Entity Framework 6.5.1, LINQ, EDMX Database First |
| Cơ sở dữ liệu | Microsoft SQL Server |
| Quản lý thư viện | NuGet với `packages.config` |

Context dữ liệu của ứng dụng kế thừa `System.Data.Entity.DbContext` (EF6). `packages.config` cũng có các gói EF Core 3.1.32 được tham chiếu trong mã nguồn hiện tại.

## Cấu trúc dự án

```text
QuanLyQuanCaPhe.sln
QuanLyQuanCaPhe/
├── BLL/                  # Xử lý tài khoản, bàn, món và hóa đơn
├── GUI/                  # Các form quản lý và hồ sơ tài khoản
├── Security/             # Hàm băm mật khẩu hiện tại
├── Properties/           # Tài nguyên và cấu hình ứng dụng
├── image/                # Hình trạng thái bàn, được chép vào thư mục build
├── images/               # Tài nguyên hình ảnh của dự án
├── Login.cs              # Màn hình đăng nhập
├── Main.cs               # Màn hình phục vụ và thanh toán
├── Model1.edmx           # Mô hình và ánh xạ cơ sở dữ liệu
├── Model1.Context.cs     # EF6 DbContext
├── App.config            # Chuỗi kết nối SQL Server
└── packages.config       # Danh sách NuGet packages
database/
└── setup.sql             # Tạo schema và dữ liệu demo từ mô hình EDMX
docs/
└── RESUME.md             # Mô tả tiếng Anh để sử dụng trong CV
```

Các form gọi lớp xử lý trong `BLL`; các lớp này truy vấn và lưu dữ liệu qua `CoffeeManagementEntities1`. Các entity và ánh xạ quan hệ được sinh từ `Model1.edmx`.

## Cài đặt và chạy

### 1. Chuẩn bị

- Windows và Visual Studio có workload **.NET desktop development**.
- .NET Framework **4.7.2 Developer/Targeting Pack**.
- SQL Server hoặc SQL Server Express, cùng SQL Server Management Studio (SSMS).
- NuGet để khôi phục các thư viện của solution.

### 2. Lấy mã nguồn

```powershell
git clone https://github.com/TienTrn05/CoffeManagement.git
cd CoffeManagement
```

### 3. Khởi tạo database demo

Mở [database/setup.sql](database/setup.sql) bằng SSMS, kết nối đến SQL Server của bạn rồi chạy script. Script tạo database `CoffeeManagement` nếu chưa tồn tại, sáu bảng theo schema trong EDMX và một ít dữ liệu mẫu. Script sẽ dừng nếu đã có bất kỳ bảng ứng dụng nào để tránh ghi đè dữ liệu hiện có. Chỉ sử dụng cho database demo mới; script không phải bản sao lưu dữ liệu gốc và không phải migration cho database đang sử dụng.

Nếu đã cài `sqlcmd`, có thể chạy từ thư mục repository (thay instance cho phù hợp):

```powershell
sqlcmd -S '.\SQLEXPRESS' -E -b -f 65001 -i database/setup.sql
```

### 4. Cấu hình kết nối

Mở `QuanLyQuanCaPhe/App.config`, tìm connection string có tên **`CoffeeManagementEntities1`**. Trong phần `provider connection string`, đổi `data source` thành SQL Server instance của bạn. Ví dụ với SQL Server Express cục bộ:

```text
data source=.\SQLEXPRESS;initial catalog=CoffeeManagement;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework
```

Giữ nguyên phần `metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl`, tên connection string và `providerName="System.Data.EntityClient"`. Chuỗi kết nối trong XML dùng `&quot;` để bao phần provider connection string. Tài khoản Windows chạy ứng dụng cần có quyền truy cập database.

### 5. Khôi phục thư viện và chạy

1. Mở `QuanLyQuanCaPhe.sln` trong Visual Studio.
2. Nhấp phải solution → **Restore NuGet Packages**.
3. Chọn `QuanLyQuanCaPhe` làm **Startup Project**.
4. Build solution và nhấn **F5** để chạy.

Có thể build bằng **Developer PowerShell for Visual Studio** nếu đã có NuGet CLI:

```powershell
nuget restore QuanLyQuanCaPhe.sln
msbuild QuanLyQuanCaPhe.sln /p:Configuration=Release
```

Khi chạy file `.exe` trực tiếp, hãy chạy từ thư mục output và giữ thư mục `image/` cạnh file thực thi vì ứng dụng tải hình trạng thái bàn từ đường dẫn tương đối.

### Tài khoản demo

Các tài khoản dưới đây chỉ được tạo khi chạy script demo:

| Vai trò | Tên đăng nhập | Mật khẩu |
| --- | --- | --- |
| Admin | `admin` | `1` |
| Staff | `staff` | `1` |

Luồng thử nhanh: đăng nhập → chọn bàn → chọn danh mục và món → thêm số lượng → chọn mức giảm giá → thanh toán.

## Mô hình dữ liệu

| Bảng | Vai trò |
| --- | --- |
| `Account` | Tên đăng nhập, tên hiển thị, mật khẩu và quyền truy cập |
| `TableFood` | Tên và trạng thái bàn |
| `Category` | Danh mục đồ uống |
| `Drink` | Đồ uống, giá bán và danh mục |
| `Bill` | Bàn, ngày vào/ra, trạng thái thanh toán, giảm giá và tổng tiền |
| `BillInfo` | Các món và số lượng trong từng hóa đơn |

Quan hệ chính: `Category` → `Drink`, `TableFood` → `Bill`, `Bill` → `BillInfo`, `Drink` → `BillInfo` (đều một–nhiều).

## Phạm vi hiện tại

- Mục **Gộp bàn** có trên giao diện nhưng handler riêng chưa được triển khai. Chức năng **Chuyển bàn** có xử lý chuyển các món sang hóa đơn bàn đích.
- Màn hình hóa đơn hiện lấy toàn bộ hóa đơn theo trang; chưa lọc theo khoảng ngày dù một số phương thức có tên `ByDate`.
- `BillForm.CurrentPage` hiện mặc định là `0` nhưng phép tính phân trang yêu cầu bắt đầu từ `1`; mở form có thể gây lỗi chỉ số danh sách. Cần khởi tạo trang hợp lệ trước khi dùng màn hình này.
- Mã nguồn hiện sử dụng MD5 cho mật khẩu và mật khẩu mặc định `1` khi tạo tài khoản. Cần thay cơ chế lưu mật khẩu và mật khẩu mặc định trước khi dùng với dữ liệu thực tế.
- Database sử dụng kiểu `date` cho ngày vào/ra hóa đơn; không lưu phần giờ. Giá tiền hiện dùng `float` trong schema gốc.

## Kiểm tra bản đóng gói

Đã đối chiếu các file nguồn/tài nguyên được tham chiếu trong `.csproj` và cấu hình loại trừ file build/cache khỏi Git. Lần thử build trong môi trường chuẩn bị repository dừng ở lỗi `MSB3644` do thiếu .NET Framework 4.7.2 reference assemblies; chưa xác nhận ứng dụng chạy hoàn chỉnh. Script database demo chưa được thực thi trên SQL Server.

## Nội dung cho resume

Xem [docs/RESUME.md](docs/RESUME.md) để lấy mô tả tiếng Anh ngắn gọn dựa trên các chức năng đã có trong mã nguồn.
