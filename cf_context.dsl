workspace {
        !identifiers hierarchical
    model {


        CoffeeCustomer = person "Khách hàng" "Customers want to buy coffee"
        
        Cashier = person "Thu ngân" "Đăng nhập thành công vào hệ thống"

        // Supplier =  person "Nhà cung cấp" ""

        Manager = person "Quản lý" ""

        EmailSystem = softwareSystem "Email System" " " "EmailSystem"

        StaffKitchen = person "Nhân viên phòng bếp" ""
        
        group "Coffee System" {

            PrintingSystem = softwareSystem "Printing System" "In các loại biên lai, báo cáo" {
                spa = container "Single-Page Application" "Cung cấp tất cả các chức năng cho việc order qua web browser " " Vuejs/Javascript"  {
                    // Cashier -> this "Xem tình trạng order, tạo order, thực hiện thanh toán, sửa order"
                }
                           
                website = container "Web Application" "Cung cấp các static file ban đầu và Order Single Page Application" "Apache"{
                    // Cashier -> this "Truy cập vào thông qua url"
                    this -> spa "Chuyển hướng đến web browser "
                }

                api = container "Print API" "Cung cấp các service In thông qua JSON/HTTPS API" "Laravel, PHP" {

                    templateComponent = component "Template Component" "CRUD các mẫu template"
                    generatorController = component "Generator Controller" "Tạo các mẫu biên lai, báo cáo thực tế thông qua các mẫu template và dữ liệu"
                    printerInterface = component "Printer Interface" "Tương tác và gửi lệnh in tới máy in để lấy biên lai"
                    spa -> templateComponent "Gọi request tới" "JSON/HTTPS"
                    generatorController -> templateComponent "Lấy ra template thích hợp"
                    generatorController -> printerInterface "Sử dụng"
                    generatorController -> EmailSystem "Gửi email bằng"
                    printerInterface -> CoffeeCustomer "Gửi biên lai"
                }
                container "Template Database" "Quản lý thông tin các hóa đơn, menu" "SQL Server" "Database"{
                    api -> this "Đọc và ghi dữ liệu vào"
                }
            }

             OrderSystem = softwareSystem "Order Management System" "" "OrderSystem" {

                spa = container "Single-Page Application" "Cung cấp tất cả các chức năng cho việc order qua web browser " " Vuejs/Javascript"  {
                    Cashier -> this "Xem tình trạng order, tạo order, thực hiện thanh toán, sửa order"
                    StaffKitchen -> this  "Cập nhật trạng thái order, xem các order mới, trả món "
                }
                           
                website = container "Web Application" "Cung cấp các static file ban đầu và Order Single Page Application" "Apache"{
                    Cashier -> this "Truy cập vào thông qua url"
                    this -> spa "Chuyển hướng đến web browser (Sau khi kiểm tra tài khoản)"
                }

                api = container "Order API" "Cung cấp các order service thông qua JSON/HTTPS API" "Laravel, PHP" {
                    OrderManagement = component "Order Management Module" "CRUD order, cập nhật trạng thái của order, thông báo khi order của khách đã hoàn thành"
                    MicroController  = component "Micro-controller " "Gửi tín hiệu đến động cơ rung để bắt đầu hoặc ngừng rung"
                    // OrderTracking = component "Order Tracking Module" "Cho NV nhà bếp cập nhật trạng thái của order, từng món trong order, hiển thị danh sách các order"
                    MenuManagement = component "Menu Management Module" "Lấy ra danh sách menu, thêm/sửa/xóa menu "
                    PaymentModule = component "Payment Module" "Xử lý các khoản thanh toán, sau này có thể tích hợp với payment gateway cho phép khách hàng thanh toán bằng credit/debit card"
                    
                    // spa -> this "Gọi request tới" "JSON/HTTPS"
                    spa -> PaymentModule "Gọi request tới" "JSON/HTTPS"
                    spa -> MenuManagement "Gọi request tới" "JSON/HTTPS"
                    spa -> OrderManagement "Gọi request tới" "JSON/HTTPS"
                    OrderManagement -> MicroController "Gọi đến khi hoàn thành order"
                    MicroController -> CoffeeCustomer "Thông báo order đã hoàn thành thông qua thẻ rung"
                    PaymentModule -> PrintingSystem.api.generatorController "In biên lai"
                
                }
                orderDB = container "Order Database" "Quản lý thông tin các hóa đơn, menu" "SQL Server" "Database"{
                    // api -> this "Đọc và ghi dữ liệu vào"
                    api.MenuManagement -> this "Đọc và ghi dữ liệu vào"
                    api.PaymentModule -> this "ghi các hóa đơn vào"
                    api.OrderManagement -> this "Đọc và ghi dữ liệu vào"
                }


             }
            

    
            InventorySystem = softwareSystem  "Inventory Management System" ""  {
                spa = container "Inventory Single-Page Application" "Cung cấp tất cả các chức năng cho việc Quản lý kho hàng qua web browser" " Vuejs/Javascript"  {
                    // Cashier -> this "Xem tình trạng order, tạo order, thực hiện thanh toán, sửa order"
                }
                           
                website = container "Web Application" "Cung cấp các static file ban đầu và Inventory Single Page Application" "Apache"{
                    // Cashier -> this "Truy cập vào thông qua url"
                    this -> spa "Chuyển hướng đến web browser "
                }

                api = container "Inventory API" "Cung cấp các service thông qua JSON/HTTPS API" "Laravel, PHP" {

                    itemListComponent = component "Item Listing Component" "Quản lý các mặt hàng trong kho, tìm kiếm, theo dõi xuất/nhập/tồn kho"
                    orderModule = component "Ordering Module " "Quản lý phiếu nhập/xuất kho,..."
                    alertComponent = component "Alert Component" "Gửi cảnh báo qua hệ thống và email cho quản lý khi mặt hàng dưới hạn mức tồn hoặc gần hết HSD"
                    reportModule = component "Reporting  Module" "Tạo ra các báo cáo, cho phép người dùng tùy chọn khoảng thời gian, thiết lập gởi báo cáo định kỳ,..."
                    
                    alertComponent -> PrintingSystem.api.generatorController "Tạo mẫu báo cáo bằng "
                    reportModule -> PrintingSystem.api.generatorController "Tạo mẫu báo cáo bằng "
                    PrintingSystem.api.generatorController -> Manager "In ra báo cáo cho"
                    spa -> alertComponent "Gọi request tới" "JSON/HTTPS"
                    spa -> itemListComponent "Gọi request tới" "JSON/HTTPS"
                    spa -> orderModule "Gọi request tới" "JSON/HTTPS"
                    spa -> reportModule "Gọi request tới" "JSON/HTTPS"
                }
                db = container "Inventory Database" "Lưu trữ các thông tin các mặt hàng, phiếu nhập xuất,..." "SQL Server" "Database"
                api.itemListComponent -> db  "Đọc, ghi dữ liệu vào"
                api.orderModule -> db  "Đọc, ghi dữ liệu vào"
                api.alertComponent -> db  "Đọc, ghi dữ liệu vào"
                api.reportModule -> db  "Đọc, ghi  dữ liệu từ"
            }
            
        }


        CoffeeCustomer -> Cashier "Yêu cầu đặt món"

        EmailSystem -> Manager  "Gửi email đến"
        
        Manager -> OrderSystem "Uses"
        
        Manager -> InventorySystem "Uses"

   
    }
    views {
        // systemContext CoffeeSystem 
        systemLandscape  {
             include *
             autoLayout lr
        }
        systemContext OrderSystem "OrderSystem" {
            include *
            autoLayout
        } 

         container "OrderSystem" {
            include *
            autolayout lr
        }

        container PrintingSystem {
            include *
            autolayout lr
        }


        component OrderSystem.api {
            include *
            autoLayout
        }
        component PrintingSystem.api {
            include * Manager
            autoLayout
        }
        component InventorySystem.api {
            include Manager * EmailSystem
            autoLayout lr
        }

       
        styles {
            element "Software System" {
                background #ca3030
                color #ffffff
            }
            element "Person" {
                shape person
                background #7e0404
                // background #ca3030
                color #ffffff
            }

            element "EmailSystem" {
                background #999999
                
                color #ffffff
            }
            
            element "Container" {
                background #ca3030
                color #ffffff
            }
            element "Database" {
                shape Cylinder
            }
            element Group {
                color #ff0000
            }
        }
    }
}