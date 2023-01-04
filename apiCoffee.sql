Create database ApiCoffee
go

use ApiCoffee
go 

CREATE TABLE menu(
	menuid int IDENTITY (1,1) NOT NULL,
	menuname NVARCHAR(1000)  NOT NULL,
	menuavata  NVARCHAR(1000)  NOT NULL, 
	PRIMARY KEY (menuid)
)
INSERT INTO menu(menuname,menuavata)
VALUES(N'Cà phê',N'https://cdn.tgdd.vn/2021/02/CookProduct/Untitled-1-1200x676-4.jpg')
INSERT INTO menu(menuname,menuavata)
VALUES(N'Trà Sữa',N'https://images.foody.vn/res/g87/866482/prof/s576x330/foody-upload-api-foody-mobile-551181e6898573db2a94-200422101814.jpg')
INSERT INTO menu(menuname,menuavata)
VALUES(N'Tráng miệng',N'https://quanghuyplaza.vn/wp-content/uploads/2022/01/mau-banh-phong-cach-han-quoc-3.jpg')

CREATE TABLE food ( 
	foodid  INT  IDENTITY (1,1) NOT NULL, 
	foodname NVARCHAR(1000)  NOT NULL, 
	menuid INT NOT NULL,
	foodprice INT NOT NULL,
	foodimghp  NVARCHAR(1000)  NOT NULL, 
	foodimg1  NVARCHAR(1000)  NOT NULL,
	foodimg2  NVARCHAR(1000) ,  
	foodimg3  NVARCHAR(1000)  ,
	foodimg4  NVARCHAR(1000)   ,
	foodDescriptions NTEXT  NOT NULL,
	foodInStock int,
	typefood int ,
	PRIMARY KEY (foodid),
			CONSTRAINT PK_menu FOREIGN KEY(menuid)
		REFERENCES menu(menuid)
	)
	GO
INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Cà phê sữa đá ',1,29000,
N'https://www.highlandscoffee.com.vn/vnt_upload/news/03_2018/_DSF5631edited-2.jpg',
N'',N'https://cf.shopee.vn/file/a7785ae000ea41f065f21a9ac2eb3f87',
N'https://bizweb.dktcdn.net/thumb/large/100/333/744/files/mau-banh-kem-hinh-trai-tim-tang-ban-gai4.jpg?v=1543199234546',
N'https://tinphatbakery.com/wp-content/uploads/2019/04/Ba%CC%81nh-Kem-Tra%CC%81i-Tim-Ti%CC%80nh-Ye%CC%82u-52.jpg',
N'Làm từ hạt cà phê thơm ngon',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Cà phê đen đá',1,29000,
N'https://aeonmall-binhduongcanary.com.vn/wp-content/uploads/2020/05/cfd.png',
N'',
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'Làm từ hạt cà phê thơm ngon',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Freeze Trà Xanh',1,49000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/11_2022/BR_Drink/HLC_New_logo_Products__FREEZE_TRA_XANH.png',
N'',
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'Freeze mát lạnh',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Freeze Socola',1,49000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/11_2022/BR_Drink/HLC__FREEZE_SO-CO-LA.jpg',
N'',
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'Freeze mát lạnh',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Trà đào cam sả',2,39000,
N'https://phache.com.vn/upload/gallery/cach-lam-tra-thach-dao-highland-1-.png',
N'',
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'Trà đào cam sả ngon',1,0)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Trà Sen Vàng',2,39000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/11_2022/BR_Drink/HLC__TRA_SEN_VANG_SEN.jpg',
N'',
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'Trà Sen Vàng ngon',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Trà Sữa Phúc Long',2,59000,
N'https://phuclong.com.vn/uploads/dish/6e1c837ccd02b3-cafe5mon05.png',
N'',
N'https://bizweb.dktcdn.net/thumb/1024x1024/100/053/059/products/banh-kem-20k.jpg?v=1502154343880',
N'https://bizweb.dktcdn.net/thumb/1024x1024/100/053/059/products/banh-kem-20k.jpg?v=1502154343880',
N'https://bizweb.dktcdn.net/thumb/1024x1024/100/053/059/products/banh-kem-20k.jpg?v=1502154343880',
N'  Trà Sữa Phúc Long',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Trà Vải',2,39000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/11_2022/BR_Drink/HLC__TRA_THACH_VAI.jpg',
N'',
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N' Trà vải',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Flan Phô mai',3,29000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/03_2018/thumbs/270_crop_CARAMELPHOMAI.jpg',
N'',
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'Đường kính bánh 10 – 15 cm, chiều cao bánh 7 – 10 cm. Bánh dùng cho 6 đến 7 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Phô mai cà phê',3,29000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/03_2018/thumbs/270_crop_PHOMAICAPHE.jpg',
N'',
N'https://cuahangbanh.com/image/cache/catalog/abum-10/banh-kem-trai-cay-dep-nhat-550x550.jpg',
N'https://cuahangbanh.com/image/cache/catalog/abum-10/banh-kem-trai-cay-dep-nhat-550x550.jpg',
N'https://cuahangbanh.com/image/cache/catalog/abum-10/banh-kem-trai-cay-dep-nhat-550x550.jpg',
N'Đường kính bánh 10 – 15 cm, chiều cao bánh 7 – 10 cm. Bánh dùng cho 6 đến 7 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Mouse Chocolate',3,35000,
N'https://www.highlandscoffee.com.vn/vnt_upload/product/03_2018/thumbs/270_crop_SOCOLAHL.png',
N'',
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'Đường kính bánh 10 – 15 cm, chiều cao bánh 7 – 10 cm. Bánh dùng cho 6 đến 7 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)




CREATE TABLE news(
  newsid INT IDENTITY (1,1) NOT NULL,
  newsname NVARCHAR(1000)  NOT NULL,
  newsavata  NVARCHAR(1000)  NOT NULL, 
  Descriptions NTEXT  NOT NULL,
  PRIMARY KEY (newsid)
)

INSERT INTO news(newsname,newsavata,Descriptions)
VALUES(N'ĐẠI TIỆC ÂM NHẠC: HIGHLANDS COFFEE 20 NĂM - GẮN KẾT NIỀM TỰ HÀO ĐẤT VIỆT
',N'https://highlandscoffee.com.vn/vnt_upload/news/10_2019/222-01.png',N'Nằm trong chương trình “20 năm – Gắn kết niềm tự hào đất Việt”, lần đầu tiên, Highlands Coffee sẽ đưa hàng nghìn người hâm mộ đến với chuỗi sự kiện âm nhạc sôi động cùng hàng loạt trải nghiệm độc đáo diễn ra tại những địa điểm mang tính biểu tượng của ba thành phố lớn Đà Nẵng (08/11), Thủ đô Hà Nội (16/11) và Tp. Hồ Chí Minh (23/11).')


INSERT INTO news(newsname,newsavata,Descriptions)
VALUES(N'ĐẠI TIỆC ÂM NHẠC: HIGHLANDS COFFEE 20 NĂM - GẮN KẾT NIỀM TỰ HÀO ĐẤT VIỆT
',N'https://cdnmedia.baotintuc.vn/Upload/DGCvMTLSo95Cq4TvfGr0A/files/2019/11/16-11/highlandcoffee.jpg',N'Nằm trong chương trình “20 năm – Gắn kết niềm tự hào đất Việt”, lần đầu tiên, Highlands Coffee sẽ đưa hàng nghìn người hâm mộ đến với chuỗi sự kiện âm nhạc sôi động cùng hàng loạt trải nghiệm độc đáo diễn ra tại những địa điểm mang tính biểu tượng của ba thành phố lớn Đà Nẵng (08/11), Thủ đô Hà Nội (16/11) và Tp. Hồ Chí Minh (23/11).')

INSERT INTO news(newsname,newsavata,Descriptions)
VALUES(N'Lịch mở cửa Tết
',N'https://www.highlandscoffee.com.vn/vnt_upload/news/02_2019/lich-hoat-dong-tet-2019.jpg',N'Nằm trong chương trình “20 năm – Gắn kết niềm tự hào đất Việt”, lần đầu tiên, Highlands Coffee sẽ đưa hàng nghìn người hâm mộ đến với chuỗi sự kiện âm nhạc sôi động cùng hàng loạt trải nghiệm độc đáo diễn ra tại những địa điểm mang tính biểu tượng của ba thành phố lớn Đà Nẵng (08/11), Thủ đô Hà Nội (16/11) và Tp. Hồ Chí Minh (23/11).')

 CREATE TABLE CustomerSP(
	 customerSPid int IDENTITY (1,1) NOT NULL,
	 customerSPname NVARCHAR(1000),
	 customerSPemail NVARCHAR(1000),
	 customerSPDescriptions NTEXT  NOT NULL,
	 PRIMARY KEY (customerSPid)
 )

 --Tạo table Slide 
create table slide(
	slideid int identity(1,1) NOT NULL,
	slidetitle nvarchar (1000) NOT NULL ,
	slidedescription nvarchar (1000),
	slideimg nvarchar(1000),
	slideActive int,
	slidetype int ,
)
insert into slide (slidetitle,slidedescription,slideimg,slideActive,slidetype )
values ( N'Cà phê',N'Thích hợp cho những buổi tiệc sinh nhật nhỏ nhắn bên cạnh những người mình yêu quý
, với giá thành rất rẻ nhưng vẫn có thể cảm nhận trọn không khí sinh nhật','https://websitecuckukvn.misacdn.net/wp-content/uploads/2022/03/nhuong-quyen-highland-coffee.png',1,1)
insert into slide (slidetitle,slidedescription,slideimg,slideActive,slidetype )
values ( N'Trà Sữa',N'Một chiếc bánh kem cân bằng dinh dưỡng với những trái cây xanh tươi, giúp cho những hội chị em hay 
những người khác có nỗi niềm sợ béo phì có thể thoải mái tham gia những bữa tiệc sinh nhật mà không phải sợ lên cân','https://websitecuckukvn.misacdn.net/wp-content/uploads/2022/03/nhuong-quyen-highland-coffee.png',0,1)
insert into slide (slidetitle,slidedescription,slideimg,slideActive,slidetype )
values ( N'Tráng miệng',N'Một chiếc bánh kem ú nụ cho một bữa tiệc sinh nhật thật hoành tráng, thích hợp cho những bữa tiệc lớn,
 tạo những kỉ niệm đáng quý cho mọi người tham gia','https://ichef.bbci.co.uk/images/ic/1200xn/p060z50q.jpg',0,1)
 
CREATE TABLE Cart ( 
	Cartid  INT  IDENTITY (1,1) NOT NULL, 
	foodid INT,
	foodname NVARCHAR(1000)  NOT NULL, 
	foodprice INT NOT NULL,
	foodimghp  NVARCHAR(1000)  NOT NULL, 
	Allprice int  NOT NULL, 
    cartquantity INT,
	PRIMARY KEY (Cartid),
	customerid int   NOT NULL,
	CONSTRAINT PK_Customer_Cart FOREIGN KEY(customerid)
	REFERENCES Customer(customerid),
	CONSTRAINT PK_Food_Cart FOREIGN KEY(foodid)
	REFERENCES food(foodid)
	)
	GO

	select * from Cart


	CREATE TABLE About ( 
	Abouttid  INT  IDENTITY (1,1) NOT NULL, 
	Abouttitle NVARCHAR(1000)  NOT NULL, 
	Aboutimg NVARCHAR(1000)  NOT NULL, 
	AboutDescriptions  NVARCHAR(1000)  NOT NULL, 
	PRIMARY KEY (Abouttid)
	)
	GO
	
	insert into About(Abouttitle,Aboutimg, AboutDescriptions)
     values(N'Home Coffee',N'https://websitecuckukvn.misacdn.net/wp-content/uploads/2022/03/nhuong-quyen-highland-coffee.png',
	 N'Home Coffee được ra đời với thông điệp mang đam mê của chúng tôi gửi gắm đến bạn qua những chiếc 
	 bánh ngọt và thức uống ngon, giá rẻ, vệ sinh và chất lượng luôn được đặt lên hàng đầu. 
	 Sự ra đời của mỗi chiếc bánh đều được chọn lọc kỹ lưỡng tâm huyết của đội ngũ chúng tôi từ khâu nguyên liệu, 
	 chế biến để khi đến tay của các bạn, chúng đều trở thành sản phẩm hoàn hảo nhất.')
	 insert into About(Abouttitle,Aboutimg, AboutDescriptions)
     values(N'MÔ HÌNH PHƯƠNG TÂY',N'https://images.foody.vn/res/g75/744393/prof/s640x400/foody-upload-api-foody-mobile-it-jpg-180524165421.jpg',
	 N'Tiệm Bánh được xây dựng và hoạt động theo mô hình phương Tây. Mỗi chiếc bánh được làm ra với phong cách mang đậm hương vị đến từ Pháp
	 và Mỹ – hai đất nước nổi tiếng tiên phong trong việc cho ra đời những món tráng miệng ngon và đẹp mắt bậc nhất thế giới.
	 ')
	

	
	CREATE TABLE Customer(
customerid int IDENTITY (1,1) NOT NULL,
customername NVARCHAR(1000)  NOT NULL,
customeremail NVARCHAR(1000)  NOT NULL,
customernuber  NVARCHAR(1000)  NOT NULL,
customerpassword NVARCHAR(1000),
PRIMARY KEY (customerid)
)


	CREATE TABLE Bill ( 
BillId  INT  IDENTITY (1,1) NOT NULL, 
Customer NVARCHAR(1000)  NOT NULL, 
Phonenumber NVARCHAR(1000)  NOT NULL, 
Address  NVARCHAR(1000)  NOT NULL, 
customerid int   NOT NULL,
DayOrder datetime DEFAULT (getdate()),
Status  INT  NOT NULL, 
PRIMARY KEY (BillId),
CONSTRAINT PK_Customer FOREIGN KEY(customerid)
	REFERENCES Customer(customerid)
	)
	GO 


	CREATE TABLE BillDetail ( 
BiDid  INT  IDENTITY (1,1) NOT NULL, 
Quantity INT  NOT NULL, 
foodname NVARCHAR(1000)  NOT NULL, 
foodprice INT NOT NULL,
BillId  INT NOT NULL, 
Allprice int  NOT NULL, 
PRIMARY KEY (BiDid),
CONSTRAINT PK_Bill FOREIGN KEY(BillId)
	REFERENCES Bill(BillId)
	)
	GO

	CREATE TABLE Comments (
commentid int IDENTITY (1,1) NOT NULL,
foodid int  NOT NULL,
foodname NVARCHAR(1000) NOT NULL,
customername NVARCHAR(1000) NOT NULL,
commentDescriptions NVARCHAR(1000) NOT NULL,
PRIMARY KEY (Commentid),
CONSTRAINT PK_food FOREIGN KEY(foodid)
REFERENCES food(foodid),
)
go

DELETE Comments

CREATE TABLE admin (
adminid int IDENTITY (1,1) NOT NULL,
UserName NVARCHAR(1000) NOT NULL,
Password NVARCHAR(1000) NOT NULL,
PRIMARY KEY (adminid),
)
go

select * from admin
 
