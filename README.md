# ASP.NET Core 8.0 project 
## Technologies
- ASP.NET Core 8.0
- Entity Framework Core 8.0
## Install Tools
- .NET Core SDK 8.0
- Visual Studio 2022
- SQL Server 2019
## How to configure and run
- Tải dự án về từ githib: https://github.com/NguyenThanhTung8503/GymShop
- Mở solution ShopGYM.sln trên Visual Studio 2019.
- Cài startup project là ShopGYM.Data.
- Đổi chuỗi kết nối trong Appsetting.json tại ShopGYM.Data.
- Mở Tools --> Nuget Package Manager -->  Package Manager Console trên Visual Studio (khi đã mở lên chú ý phần Default project xem có phải là ShopGYM.Data không nếu không phỉa hãy chỉnh lại).
- Chạy lệnh Update-database và nhấn Enter.
- Sau khi migrate database thành công, cài Startup Project là ShopGYM.WebApp.
- Đổi chuỗi kết nối trong appsettings.Development.json tại ShopGYM.WebApp.
- Thanh toán qua Momo: 
	- Bạn cần tải Ngrok tại link: https://ngrok.com/downloads/windows?tab=download 
	- Truy cập vào https://dashboard.ngrok.com/get-started/setup/windows để xem hướng dẫn setup. 
	- Mở ngrok lên chạy lệnh: ngrok http https://localhost:5003
	- Ngrok sẽ hiện link thay thế https://localhost:5003, lấy link đó dán vào Appsetting.json tại ShopGYM.WebApp thay thế ReturnUrl và NotifyUrl (Giữ nguyên /Payment/...trong đường dẫn).
	- Truy cập vào link: https://developers.momo.vn/v3/download/ để tải app momo test.
	- Truy cập link: https://developers.momo.vn/v3/vi/docs/payment/onboarding/test-instructions/ để đọc hướng dẫn đăng ký tài khoản test.
- Thiết lập nhiều dự án chạy: Nhấp chuột phải vào Solution và chọn Properties và thiết lập Multiple Project, chọn Start cho 3 Project: BackendApi, WebApp and AdminApp.
- Chạy dự án
- Đăng nhập Admin: tài khoản: admin, mật khẩu: Tung1234,
