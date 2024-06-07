USE [HoaLacLaptopShop]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (87, N'Intel', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (88, N'NVIDIA', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (89, N'Asus', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (90, N'Acer', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (91, N'AMD', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (92, N'Dell', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (93, N'Lenovo', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (94, N'MSI', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (95, N'LG', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (96, N'Gigabyte', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (97, N'Akko', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (98, N'FLEsport', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (99, N'Newmen', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (100, N'Rapoo', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (101, N'Logitech', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (102, N'Corsair', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (103, N'AULA', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (104, N'E-DRA', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (105, N'ASUS ROG', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (106, N'Dareu', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (107, N'STEELSERIES', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (108, N'HyperX', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (109, N'Wiwu', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (110, N'Boona', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (111, N'HyperWork', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (112, N'COOLER MASTER', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (113, N'Handboss', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (114, N'HP', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (115, N'ORICO', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (116, N'Ugreen', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (117, N'TP-LINK', N'abc', N'US')
INSERT [dbo].[Brands] ([id], [name], [description], [country]) VALUES (118, N'LDNIO', N'abc', N'US')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (250, 89, N'Asus Gaming TUF FX507ZC4-HN074W', 18999000, 35, N'Description: 

Laptop Asus Gaming TUF FX507ZC4-HN074W


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: 90NR0GW2-M00530
• Bộ vi xử lý: 12th Gen Intel Core i5-12500H Processor 2.5 GHz (18M Cache, up to 4.5 GHz, 12 cores: 4 P-cores and 8 E-cores)
• Chipset: N/A
• Bộ nhớ trong: DDR4 8GB
• Expansion Slot(includes used): 2x DDR4 SO-DIMM slots
• Dung lượng tối đa: 32GB
• VGA: NVIDIA GeForce RTX 3050 Laptop GPU
• Ổ cứng: 512GB PCIe 3.0 NVMe M.2 SSD
• Security: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 15.6-inch, FHD (1920 x 1080) 16:9, 144Hz refresh rate, 45% NTSC, 62.5% SRGB, Anti-glare Display
• Webcam: 720P HD camera
• Audio: 
        - AI noise-canceling technology
        - Dolby Atmos
        - Hi-Res certification
        - Built-in array microphone
• Giao tiếp không dây: Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.2 (*Bluetooth version may change with OS version different.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x Thunderbolt 4 support DisplayPort
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort / G-SYNC
        - 2x USB 3.2 Gen 1 Type-A
        - 1x HDMI 2.1 TMDS
        - 1x 3.5mm Combo Audio Jack
• Pin: 56WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 25.1 x 2.24 ~ 2.49 cm
• Cân nặng: 2.20 kg
• Hệ điều hành: Windows 11 Home
• Included in the Box: N/A', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (251, 89, N'Asus Gaming TUF FX506HF-HN078W', 16899000, 19, N'Description: 

Hiệu năng Gaming mạnh mẽ
Laptop Asus TUF Gaming F15 FX506HF-HN078W mang hiệu năng tuyệt vời giúp bạn luôn sẵn sàng chinh phục mọi thử thách, thực hiện tốt mọi tác vụ với CPU Intel Core i5-11260H 6 nhân 12 luồng mạnh mẽ, mức xung nhịp đạt 4.4GHz. Khả năng đồ hoạt mượt mà với trang bị GPU GeForce RTX™ 2050 4GB GDDR6, do đó, bạn có thể làm đồ họa, chơi vô vàn tựa game với tốc độ khung hình ổn định.
Bộ nhớ trong RAM 16GB DDR4 cung cấp khả năng đa nhiệm mượt mà cùng với khả năng lưu trữ lớn đến từ ổ cứng SSD 512GB M.2 NVMe PCIe, ngoài ra, máy còn được thiết kế để dễ dàng nâng cấp, bổ sung RAM vs SSD. Đi cùng với đó là chipset cao cấp được kết hợp trọng máy, tất cả đều mang lại cho bạn những trải nghiệm thú vị và êm ái.

Hình ảnh sắc nét, chân thực
Asus TUF Gaming F15 FX506HF-HN078W sở hữu màn hình 15.6" tỉ lệ 16:9, tấm nền IPS cao cấp, độ phân giải Full HD 1920x1080, mang đến khả năng hiển thị chi tiết và chân thực cao. Màn hình có tần số làm mới 144Hz và công nghệ chống chói, cho hình ảnh mượt mà, nhanh chóng và tinh tế khi chơi game.

Âm thanh trong trẻo tích hợp công nghệ AI
Asus TUF Gaming F15 FX506HF-HN078W mang đến trải nghiệm âm thanh đỉnh cao nhờ công nghệ DTS™ Ultra. Âm thanh luôn trong trẻo với âm sắc rõ ràng, tối ưu hóa cho các tựa game chiến lược, nhập vai và bắn súng. Được trang bị hai loa mạnh mẽ, máy cung cấp âm thanh lớn, mạnh mẽ và trải nghiệm âm thanh vòm 7.1 kênh, cho phép người chơi cảm nhận không gian trong game chân thực hơn, nâng cao khả năng định vị đối thủ.
Công nghệ chống ồn AI hai chiều giúp giảm thiểu tiếng ồn xung quanh, mang lại chất lượng giao tiếp rõ ràng hơn. Với 8 chế độ âm thanh tùy chỉnh cho nghe nhạc, xem phim và chơi game, người dùng có thể dễ dàng tối ưu hóa trải nghiệm âm thanh theo sở thích cá nhân. Bộ cân bằng tích hợp cho phép bạn tự do điều chỉnh cài đặt âm thanh, đảm bảo mọi trải nghiệm đều đạt đến mức hoàn hảo.

Khả năng tản nhiệt
Là một chiếc laptop gaming, Asus TUF Gaming F15 FX506HF-HN078W chú trọng đặc biệt đến hệ thống tản nhiệt. Máy luôn duy trì độ mát mẻ nhờ vào hệ thống tản nhiệt toàn diện, tăng cường độ tin cậy và kéo dài tuổi thọ. Với 4 ống dẫn nhiệt và 3 bộ tản nhiệt, nhiệt lượng được đẩy ra khỏi phần cứng một cách hiệu quả, giúp luồng khí tăng thêm 10% và duy trì nhiệt độ ở mức tối ưu. Hệ thống tản nhiệt của máy còn được nâng cấp với công nghệ tự làm sạch 2.0, ngăn ngừa mảnh vụn và bụi bẩn tích tụ, đảm bảo hiệu suất tản nhiệt luôn ở mức cao nhất. Nhờ đó, Asus TUF Gaming F15 không chỉ hoạt động mạnh mẽ và bền bỉ mà còn đảm bảo trải nghiệm chơi game mượt mà và ổn định.

Bàn phím tối ưu cho gaming
Asus TUF Gaming F15 FX506HF-HN078W trang bị bàn phím đèn nền RGB rực rỡ, cho phép người dùng thể hiện cá tính độc đáo. Được tối ưu hóa cho game thủ, bàn phím nổi bật với cụm phím WASD, giúp thao tác nhanh chóng và chính xác. Công nghệ Overstroke mang lại tốc độ phản hồi nhanh, cho phép bạn dễ dàng điều khiển trong mọi tình huống. Bàn phím còn nổi bật với độ bền vượt trội, mỗi phím có thể chịu được tới 20 triệu lần nhấn, đảm bảo sự bền bỉ và tin cậy trong suốt quá trình sử dụng.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: 90NR0HB4-M00A30
• Bộ vi xử lý: Intel Core i5-11260H Processor 2.9 GHz (12M Cache, up to 4.4 GHz, 6 Cores)
• Chipset: Mobile Intel HM570 Express Chipsets
• Bộ nhớ trong: DDR4 16GB
• Số khe cắm: 2x SO-DIMM slots
• M.2 SSD Support List: 
        - M.2 512GB G3x4 PCIe SSD
        - M.2 1TB G3x4 PCIe SSD
• Expansion Slot (includes used): 
        - 2x DDR4 SO-DIMM slots
        - 2x PCIe
• Dung lượng tối đa: 32GB
• VGA: NVIDIA GeForce RTX 2050 Laptop GPU
• Ổ cứng: 512GB PCIe 3.0 NVMe M.2 SSD
• Màn hình: 15.6-inch FHD (1920 x 1080) 16:9 144Hz Value IPS-level anti-glare display
• Webcam: 720P HD camera
• Giao tiếp mạng: 10/100/1000 Mbps
• Pin: 48WHrs, 3S1P, 3-cell Li-ion
• Kích thước (rộng x dài x cao): 35.9 x 25.6 x 2.28 ~ 2.45 cm
• Cân nặng: 2.30 Kg
• Hệ điều hành: 
        - Windows 11 Home
        - McAfee 30 days free trial', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (252, 90, N'Acer Nitro V ANV15-51-58AN', 19999000, 11, N'Description: 

Laptop Acer Nitro V ANV15-51-58AN
Cấu hình mạnh luôn là ưu tiên hàng đầu của một chiếc Laptop Gaming hiệu năng cao. Acer Gaming Nitro V được trang bị CPU Intel® Core™ i5-13420H thế hệ 13 mới nhất với 8 nhân và 12 luồng cùng với VGA RTX 2050, giúp Gamers tận hưởng các tựa game từ AAA đến game Esport. Kết hợp cùng bộ nhớ RAM DDR5 5200Mhz, khả năng xử lý đa nhiệm và đa tác vụ của máy càng được tăng tốc tối đa.

MÀN HÌNH 15.6″ FHD IPS 144HZ PHÙ HỢP CHO GAME THỦ
Tận hưởng các cuộc phiêu lưu vào thế giới Gaming, giải trí sống động trên màn hình 15.6″ IPS độ phân giải FHD (1920×1080), tần số quét chuẩn chiến Game 144Hz.

TẢN NHIỆT 2 QUẠT MÁT LẠNH
Giữ bình tĩnh giữa những trận chiến khốc liệt nhất nhờ quạt kép cải tiến và hệ thống xả hiệu quả của Nitro V. Khi bạn sắp xếp giải quyết các xung đột giữa các vì sao, chiếc Nitro V của bạn vẫn luôn thanh thản như không gian sâu thẳm.

ĐA KẾT NỐI – SIÊU TỐC ĐỘ
Dù là ở bất kì nơi đâu, tốc độ kết nối luôn nhanh và ổn định khi có Wi-Fi 6 và công nghệ Gigabit Ethernet. Bất cứ ở đâu, Nitro V vẫn luôn mang về chiến thắng.

TINH CHỈNH KHÔNG GIỚI HẠN VỚI NITROSENSE™
Định hướng chiến lược Gaming của bạn bằng ứng dụng tiện ích NitroSense. Ứng dụng cho phép Gamers thỏa sức tinh chỉnh mọi thiết lập cần thiết phù hợp phong cách, từ chỉnh tốc độ quạt cho đến ánh sáng đèn LED bàn phím.

GIAO TIẾP TỐT HƠN MANG VỀ CHIẾN THẮNG
Công nghệ DTS® X: Ultra Audio mang đến lợi thế về âm thanh trong các trận chiến Gaming. Cùng với đó là việc giao tiếp và trao đổi trong team tốt hơn nhờ tính năng Acer PurifiedView và PurifiedVoice đem đến chất lượng hình ảnh và âm thanh tuyệt vời.


Detailed Specifications: 


• Hãng sản xuất: Acer
• Chủng loại: Acer Nitro V ANV15-51-58AN
• Part Number: NH.QNASV.001
• Mầu sắc: Đen (Obsidian black)
• Bộ vi xử lý: Intel Core i5-13420H upto 4.60 GHz
• Chipset: Intel
• Bộ nhớ trong: 8GB DDR5 upto 5200Mhz
• Số khe cắm: 2 khe
• Dung lượng tối đa: Nâng cấp tối đa 32GB
• VGA: NVIDIA GeForce RTX 2050 with 4 GB of dedicated GDDR6 VRAM
• Ổ cứng: 512GB PCIe NVMe SSD (nâng cấp tối đa 2TB SSD)
• Ổ quang: None
• Card Reader: None
• Bảo mật, Công nghệ: 
        - Acer Bio-Protection fingerprint solution, featuring computer protection and
        - Windows Hello Certification
        - Firmware Trusted Platform Module (TPM) solution
        - BIOS user, supervisor passwords,
        - Kensington lock slot
• Màn hình: 15.6 inch FHD IPS 144Hz SlimBezel, FHD(1920 x 1080), Acer ComfyView,
• Webcam: 720p HD
• Giao tiếp mạng: LAN
• Giao tiếp không dây: 
        - WLAN
        - 802.11a/b/g/n/ac+ax wireless LAN
        - Dual Band (2.4 GHz and 5 GHz)
        - 2x2 MU-MIMO technology
        - Supports Bluetooth 5.1 or above
        - LAN
        - Gigabit Ethernet
• Cổng giao tiếp: 
        - 1 x USB Type-C port supporting:
        - USB 3.2 Gen 2 (up to 10 Gbps)
        - DisplayPort over USB-C
        - Thunderbolt 4
        - USB charging 5 V; 3 A
        - DC-in port 20 V; 65 W
        - 3 x USB Standard-A ports, supporting:
        - One port for USB 3.2 Gen 1 featuring power off USB charging
        - Two ports for USB 3.2 Gen 1
        - 1 x HDMI 2.1 port with HDCP support
        - 1 x 3.5 mm headphone/speaker jack, supporting headsets with built-in
        - microphone
        - 1 x Ethernet (RJ-45) port
        - 1 x DC-in jack for AC adapter
• Pin: 57 Wh 4-cell Li-ion battery
• Kích thước (rộng x dài x cao): 362.3 (W) x 239.89 (D) x 22.9/26.9 (H) mm
• Cân nặng: 2.1kg
• Hệ điều hành: Windows 11 Home
• Phụ kiện đi kèm: Cáp + Sạc', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (253, 90, N'Acer Nitro V ANV15-51-72VS', 24999000, 77, N'

Detailed Specifications: 


• Hãng sản xuất: Acer
• Chủng loại: Acer Nitro V ANV15-51-72VS
• Part Number: NH.QNASV.004
• Mầu sắc: Đen (Obsidian black)
• Bộ vi xử lý: Intel Core i7-13620H upto 4.90 GHz
• Chipset: Intel
• Bộ nhớ trong: 2*8GB DDR5 upto 5200Mhz
• Số khe cắm: 2 khe
• Dung lượng tối đa: Nâng cấp tối đa 32GB
• VGA: NVIDIA GeForce RTX 2050 with 4 GB of dedicated GDDR6 VRAM
• Ổ cứng: 512GB PCIe NVMe SSD (nâng cấp tối đa 2TB SSD)
• Ổ quang: None
• Card Reader: None
• Bảo mật, Công nghệ: 
        - Acer Bio-Protection fingerprint solution, featuring computer protection and
        - Windows Hello Certification
        - Firmware Trusted Platform Module (TPM) solution
        - BIOS user, supervisor passwords,
        - Kensington lock slot
• Màn hình: 15.6 inch FHD IPS 144Hz SlimBezel, FHD(1920 x 1080), Acer ComfyView,
• Webcam: 720p HD
• Audio: 
        - DTS X:Ultra Audio, featuring optimized Bass, Loudness, Speaker
        - Protection with up to 6 custom content modes by smart amplifier
        - Supported in Windows Spatial Sound for PC Gaming with DTS
        - license integrated
        - Immersive audio rendering over headphones and internal speakers
        - High SNR DAC with 2.1 Vrms out capability and can driver high
        - impedance headphone (up to 600 ohm)
        - Acer Purified.Voice technology with AI noise reduction in dual builtin
        - microphones. Features include far-field pickup, dynamic noise
        - reduction through neural network, adaptive beam forming, and predefined
        - personal and conference call modes.
        - Compatible with Cortana with Voice
        - Acer TrueHarmony technology for lower distortion, wider frequency
        - range, headphone-like audio and powerful sound
• Giao tiếp mạng: Gigabit Ethernet LAN
• Giao tiếp không dây: 
        - WLAN
        - 802.11a/b/g/n/ac+ax wireless LAN
        - Dual Band (2.4 GHz and 5 GHz)
        - 2x2 MU-MIMO technology
        - Supports Bluetooth 5.1 or above
        - LAN
        - Gigabit Ethernet
• Cổng giao tiếp: 
        - 1 x USB Type-C port supporting:
        - USB 3.2 Gen 2 (up to 10 Gbps)
        - DisplayPort over USB-C
        - Thunderbolt 4
        - USB charging 5 V; 3 A
        - DC-in port 20 V; 65 W
        - 3 x USB Standard-A ports, supporting:
        - One port for USB 3.2 Gen 1 featuring power off USB charging
        - Two ports for USB 3.2 Gen 1
        - 1 x HDMI 2.1 port with HDCP support
        - 1 x 3.5 mm headphone/speaker jack, supporting headsets with built-in
        - microphone
        - 1 x Ethernet (RJ-45) port
        - 1 x DC-in jack for AC adapter
• Pin: 57 Wh 4-cell Li-ion battery
• Kích thước (rộng x dài x cao): 362.3 (W) x 239.89 (D) x 22.9/26.9 (H) mm
• Cân nặng: 2.1kg
• Hệ điều hành: Windows 11 Home
• Phụ kiện đi kèm: Cáp + Sạc', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (254, 89, N'Asus Gaming TUF FA507NU-LP131W', 22499000, 26, N'Description: 

ĐẶC ĐIỂM NỔI BẬT
Bộ vi xử lý AMD Ryzen R5-7535HS cho hiệu suất tối đa, hỗ trợ làm việc, chơi game đa nhiệm.
Card đồ họa NVIDIA GeForce RTX 4050 xử lý đồ họa cao, giúp chỉnh sửa ảnh, 2D, 3D,... trơn tru, mượt mà.
Màn hình 15.6 inch cùng tần số quét 144 Hz giảm độ trễ, giảm thiểu giật hình cho trải nghiệm chơi game mượt mà và sống động.
16 RAM DDR5 4800MHz tiên tiến, giúp thực hiện đa nhiệm hiệu quả hơn, cho trải nghiệm phát trực tiếp, chơi game, lướt web nhanh nhạy.
Ổ cứng 1TB SSD tốc độ cao, giúp khởi động, mở ứng dụng, tải game cực nhanh.
Laptop Asus TUF Gaming A15 FA507NU-LP113W - Hiệu năng xử lý mượt mà, chất lượng hiển thị sắc nét
Laptop Asus TUF Gaming A15 FA507NU-LP113W nổi bật với thiết kế thời thượng và sang trọng, cùng khối lượng chỉ 2.2kg, khá thuận tiện trong quá trình di chuyển. Mẫu laptop Asus gaming này được đánh giá là sự kết hợp xuất sắc giữa hiệu suất và di động, hứa hẹn tạo nên một trải nghiệm xử lý công việc, giải trí tuyệt vời cho game thủ và người dùng đòi hỏi cả hiệu suất lẫn tính linh hoạt.
Hiệu năng xử lý tính toán, đồ họa khủng với chip AMD Ryzen 5 và VGA cao cấp
Laptop Asus TUF Gaming A15 FA507NU-LP113W nổi bật hơn hẳn so với các đối thủ cùng phân khúc khác nhờ sở hữu CPU mạnh mẽ hàng đầu của AMD ở thời điểm hiện tại - AMD Ryzen 5 7535HS. Qua đó, thế hệ laptop này cung cấp sức mạnh đáng kinh ngạc cho việc chơi game và xử lý đồ họa nặng.

Đi kèm với con chip xử lý cực mạnh này là card đồ họa NVIDIA GeForce RTX 4050, cung cấp hiệu suất xử lý đồ họa cao cấp, đảm bảo trải nghiệm chơi game chân thực và thực sự mượt mà. Kết hợp với đó là hệ thống tản nhiệt tiên tiến với 5 ống dẫn nhiệt và 4 khe thoát khí, cùng quạt Arc Flow với 84 cánh, đảm bảo máy luôn mát mẻ ngay cả khi chạy các tác vụ nặng.
Thoải mái lưu trữ dữ liệu và đa nhiệm không giới hạn với bộ nhớ cỡ lớn
Về các thông số bộ nhớ laptop Asus TUF Gaming A15 FA507NU-LP113W cũng không hề khiến cho người tiêu dùng phải thất vọng khi sở hữu RAM 16 GB, cung cấp đủ khả năng xử lý mạnh mẽ cho các tác vụ đa nhiệm và chơi game nặng. Bộ nhớ RAM này giúp máy hoạt động mượt mà, ngay cả khi chạy các ứng dụng đòi hỏi nhiều tài nguyên hoặc trong các phiên chơi game dài.

Còn ổ cứng SSD trên máy cũng đạt tới thông số lưu trữ 1TB, cung cấp không gian ghi nhớ lớn và tốc độ truy cập dữ liệu nhanh chóng, giảm thời gian chờ đợi khi khởi động máy và mở ứng dụng. Sự kết hợp giữa RAM và SSD này tạo nên một hệ thống tuyệt vời cho hiệu suất và độ phản hồi nhanh.
Thiết kế hầm hố, chuẩn Gaming, tạo điểm nhấn bắt mắt cho góc giải trí
Laptop Asus TUF Gaming A15 FA507NU-LP113W mang trong mình một thiết kế mạnh mẽ và cá tính, phản ánh chất gaming đích thực. Với trọng lượng chỉ 2.2kg, máy là sự kết hợp tinh tế giữa sự di động và độ bền, phù hợp với cả game thủ di động lẫn người dùng làm việc cần sự linh hoạt. Bề ngoài của laptop được hoàn thiện với tông màu đen đặc trưng, tạo nên vẻ ngoài huyền bí và chuyên nghiệp.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Chủng loại: Asus Tuf gaming
• Part Number: FA507NU-LP131W
• Mầu sắc: Xám
• Chất liệu: Nhựa ABS
• Bộ vi xử lý: AMD Ryzen 5 7535HS/H Mobile Processor (6-core/12-thread, 16MB L3 cache, up to 4.5 GHz max boost)
• Chipset: None
• Bộ nhớ trong: 16G
• Số khe cắm: 2
• Số khe RAM chờ: 0
• Dung lượng tối đa: 32G
• VGA: NVIDIA GeForce RTX 4050 Laptop GPU
• Ổ cứng: 1TB PCIe 4.0 NVMe M.2 SSD
• Ổ quang: None
• Card Reader: None
• Màn hình: 15.6-inch FHD (1920 x 1080) 16:9
• Webcam: 720P HD camera
• Audio: 
        - AI noise-canceling technology
        - Dolby Atmos
        - Hi-Res certification
        - Support Microsoft Cortana near field/Far field
• Giao tiếp mạng: 10/100/1000 Mbps
• Pin: 90WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 25.1 x 2.24 ~ 2.49 cm
• Cân nặng: 2.20kg
• Hệ điều hành: Win 11 Home
• Phụ kiện đi kèm: Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (255, 89, N'Asus Gaming TUF FX507VU-LP198W', 26999000, 65, N'Description: 

PHONG CÁCH THIẾT KẾ MỚI MẺ

BÀN PHÍM TỐI ƯU ĐA NHIỆM

HIỆU NĂNG MẠNH MẼ CÂN MỌI TÁC VỤ

TẢN NHIỆT HIỆU QUẢ

HOẠT ĐỘNG BỀN BỈ CẢ NGÀY DÀI

ÂM THANH SIÊU THỰC CÙNG DOLBY ATMOS

ĐỘ BỀN CHUẨN QUÂN ĐỘI MỸ

TRẢI NGHIỆM MỌI LOẠI GAME CÙNG PC GAME PASS

CHIẾN THẮNG MỌI CUỘC CHIẾN CÙNG TUF FX507VU-LP198W


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: 90NR0CJ8-M00CF0
• Bộ vi xử lý: 13th Gen Intel Core i7-13620H Processor 2.4 GHz (24M  Cache, up to 4.9 GHz, 10 cores: 6 P-cores and 4 E-cores)
• Chipset: Intel Iris Xe Graphics
• Bộ nhớ trong: 8GB DDR5-4800 SO-DIMM (DDR5 8GB)
• Số khe cắm: 2
• M.2 SSD Support List: 
        - M.2  2TB G4X4 PCIe SSD
        - M.2 1TB G4X4 PCIe SSD
        - M.2 512GB G4X4 PCIe SSD
• Expansion Slot (includes used): 
        - 2x DDR5 SO-DIMM slots
        - 2x PCIe
• Dung lượng tối đa: 32GB
• VGA: NVIDIA GeForce RTX 4050 Laptop GPU
• Ổ cứng: 1TB PCIe 4.0 NVMe M.2 SSD
• Bảo mật, Công nghệ: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 
        - 15.6-inch, FHD (1920 x 1080) 16:9, 144Hz,
        - 85/85/85/85 , Value IPS-level , 250nits, 1000:1 , Anti-glare display
• Webcam: 720P HD camera
• Audio: 
        - AI noise-canceling technology
        - Dolby Atmos
        - Hi-Res certification
        - Support Microsoft Cortana near field/Far field
• Giao tiếp mạng: 10/100/1000 Mbps
• Giao tiếp không dây: Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.1 Wireless Card (*Bluetooth version may change with OS version different.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x Thunderbolt 4 support DisplayPort
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC
        - 2x USB 3.2 Gen 1 Type-A
• Pin: 90WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 25.1 x 2.24 ~ 2.49 cm (13.94" x 9.88" x 0.88" ~ 0.98")
• Cân nặng: 2.20 Kg (4.85 lbs)
• Hệ điều hành: 
        - Windows 11 Home
        - McAfee 30 days free trial', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (256, 89, N'Asus Gaming TUF FA507UV-LP090W', 31999000, 85, N'Description: 

Thiết kế mỏng nhẹ
Laptop Gaming ASUS TUF Gaming A15 FA507UV-LP090W được thiết kế theo phong cách gaming mạnh mẽ với các đường nét góc cạnh và logo TUF Gaming nổi bật. Máy được hoàn thiện nhôm và nhựa cao cấp, mang đến độ bền bỉ cao và khả năng chịu lực tốt, đạt chuẩn độ bền quan đội Mỹ.

Hiệu năng vượt trội
Laptop Gaming ASUS TUF Gaming A15 FA507UV-LP090W được trang bị bộ vi xử lý AMD Ryzen 9 8945H với  8 nhân 16 luồng, tốc độ xung nhịp tối đa lên đến 5.2 GHz, mang đến hiệu năng mạnh mẽ để xử lý mọi tác vụ nặng, từ chơi game AAA, đồ họa, chỉnh sửa video cho đến lập trình.

Màn hình đỉnh cao
Laptop Gaming ASUS TUF Gaming A15 FA507UV-LP090W sở hữu màn hình 15.6 inch Full HD (1920 x 1080) với tần số quét 144Hz và tấm nền IPS cho hình ảnh sắc nét, sống động và góc nhìn rộng. Màn hình này cũng được bao phủ 100% gam màu sRGB, đảm bảo khả năng hiển thị màu sắc chính xác cho các công việc sáng tạo như chỉnh sửa ảnh, video và công nghệ G-Sync giúp loại bỏ hiện tượng xé hình, mang đến trải nghiệm chơi game mượt mà và ấn tượng.

Bàn phím và touchpad êm ái
Laptop Gaming ASUS TUF Gaming A15 FA507UV-LP090W sở hữu bàn phím chiclet với hành trình phím 1.7mm, đèn nền RGB 1 vùng và các phím WASD được làm nổi bật giúp bạn dễ dàng thao tác trong game. Touchpad của máy cũng có kích thước lớn và độ nhạy cao, mang đến trải nghiệm di chuột mượt mà và chính xác.

Âm thanh sống động
Laptop Gaming ASUS TUF Gaming A15 FA507UV-LP090W được trang bị hệ thống âm thanh Hi-Res Audio với công nghệ Dolby Atmos mang đến âm thanh sống động và chân thực, giúp bạn đắm chìm trong thế giới game.

Cổng kết nối đa dạng
Laptop Gaming ASUS TUF Gaming A15 FA507UV-LP090W được trang bị đầy đủ các cổng kết nối cần thiết như USB-C 3.2 Gen 2 (DisplayPort / Power Delivery), USB-C 4.0 (DisplayPort), 2x USB-A 3.2 Gen 1, HDMI 2.1, LAN, Audio/Mic 3.5mm đáp ứng mọi nhu cầu sử dụng nhiều thiết bị gaming gear hay setup với nhiều màn hình.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: 90NR0I28-M00560
• Bộ vi xử lý: AMD Ryzen 9 8945H Processor 4GHz (24MB Cache, up to 5.2 GHz, 8 cores, 16 Threads); AMD Ryzen AI up to 39 TOPs
• Chipset: AMD Radeon Graphics
• Bộ nhớ trong: 16GB DDR5-5600 SO-DIMM (DDR5 16GB)
• Số khe cắm: 2
• M.2 SSD Support List: 
        - M.2 PCIe 512GB
        - M.2 PCIe 1TB
        - M.2 PCIe 2TB
• Dung lượng tối đa: 32GB
• VGA: NVIDIA GeForce RTX 4060 Laptop GPU
• Ổ cứng: 512GB PCIe 4.0 NVMe M.2 SSD
• Bảo mật, Công nghệ: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 
        - 15.6-inch FHD (1920 x 1080) 16:9 - 144Hz,
        - Value IPS-level, 250, 1000:1 , Anti-glare display
• Webcam: 720P HD camera
• Audio: 
        - AI noise-canceling technology
        - Dolby Atmos
        - Hi-Res certification
        - Support Microsoft Cortana near field/Far field
• Giao tiếp mạng: 10/100/1000 Mbps
• Giao tiếp không dây: Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.3 Wireless Card (*Bluetooth version may change with OS version different.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x Type C USB 4 support DisplayPort
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC
        - 2x USB 3.2 Gen 1 Type-A
• Pin: 90WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 25.1 x 35.4 x 2.24 ~ 2.49 cm (9.88" x 13.94" x 0.88" ~ 0.98")
• Cân nặng: 2.20 Kg (4.85 lbs)
• Hệ điều hành: 
        - Windows 11 Home
        - 1-month trial for new Microsoft 365 customers. Credit card required.
        - Antivirus : McAfee 30 days free trial', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (257, 89, N'Asus Gaming TUF FA506NF-HN005W', 16499000, 83, N'Description: 

Sức mạnh đáng tin cậy
Asus TUF Gaming A15 mang hiệu năng đáng tin cậy để chơi game, thực hiện đa tác vụ với bộ xử lý AMD Ryzen 5 7535HS có thể kích hoạt tới 12 luồng để cung cấp năng lượng cho các tác vụ đa nhiệm. Kết hợp với đó là GPU rời NIVIDIA Geforce RTX 2050 giúp tạo nên tốc độ khung hình đáng kinh ngạc trong các tựa game phổ biến hiện nay. Tăng tốc độ thời gian tải khi khởi động máy hay các ứng dụng với ổ cứng SSD NVMe 512GB với khả năng nâng cấp thêm 1 ổ SSD thứ hai, cho bạn không gian siêu rộng lớn để lưu trữ các tựa game yêu thích.


Thiết kế sang trọng, sắc sảo
Asus TUF Gaming A15 FA506NF mang phong cách đậm chất gaming nổi bật với màu sắc Đen than chì đẹp mắt. Hoàn thiện với kim loại được đánh bóng với các nét đường nét dạng sợi tương phản trên khung máy được cắt gọn gàng. Mặt đáy của máy được thiết kế dạng tổ ong giúp tối ưu cho hệ thống làm mát. Một đồng minh đáng tin cậy cho dù bạn ở bất cứ đâu với tính di động của chiếc laptop Asus TUF Gaming này, di động và bền bỉ, cho phép bạn kết nối với thế giới mà không cần phải thông qua dây nối với Wi-fi 6 802.11ax nhanh chóng, tin cậy đảm bảo cho kết nối mạng để tối ưu cho công việc và giải trí của bạn ở bất cứ nơi nào có kết nối tương thích.

Âm thanh vòm ảo rõ ràng
Với công nghệ DTS:X™ Ultra giúp đem lại âm thanh chính xác, độ trung thực cao. Thanh vòm ảo 7.1 nâng cao nhận thức về không gian trong game, tối ưu hóa cho các tựa game chiến thuật, bắn súng, RPG,… Lên tới 8 chế độ cài sẵn cho phép bạn tinh chỉnh theo ý muốn giúp tối ưu cho các trải nghiệm của bạn với trong các thể loại âm nhạc, phim ảnh và trò chơi. Đi cùng với đó là công nghệ khử tiếng ồn AI 2 chiều cho phép bạn loại bỏ tiếng ồn từ cả đầu ra lẫn đầu vào, để bạn có thể giao tiếp trong trò chơi luôn rõ ràng với âm thanh trong trẻo.

Độ bền chuẩn quân đội Mỹ
Độ bền chuẩn quân đội Hoa Kỳ MIL-STD 810H tạo sự đáng tin cậy với khả năng chịu đựng những va đập vô tình thường ngày. Pin 48Wh mạnh mẽ kết hợp với CPU AMD Ryzen tiết kiệm năng lượng giúp cung cấp thời lượng pin dài với lên đến 13.5 giờ duyệt web, xem video lên tới 14.5 giờ. Ngoài ra, máy còn được trang bị công nghệ sạc nhanh với 50% pin chỉ trong 30 phút, không là gián đoạn quá lâu trong quá trình sử dụng.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: 90NR0JE7-M001E0
• Bộ vi xử lý: AMD Ryzen 5 7535HS Processor 3.3GHz (19MB Cache, up to 4.55 GHz, 6 cores, 12 Threads)
• Chipset: AMD Radeon Graphics
• Bộ nhớ trong: 8GB DDR5-5600 SO-DIMM (DDR5 8GB)
• Số khe cắm: 2
• Dung lượng tối đa: 32GB
• VGA: NVIDIA GeForce RTX 2050 Laptop GPU
• Ổ cứng: 512GB PCIe 4.0 NVMe M.2 SSD
• Expansion Slot(includes used): 
        - 2x DDR5 SO-DIMM slots
        - 2x PCIe
• M.2 SSD Support List: 
        - M.2 512GB G4x4 PCIe SSD
        - M.2 1TB G4x4 PCIe SSD
• M.2 slots support either SATA or NVMe: 2
• Bảo mật, Công nghệ: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
• Màn hình: 
        - 15.6-inch, FHD (1920 x 1080) 16:9, 144Hz, 85/85/85/85,
        - Value IPS-level , 250nits, 1000:1 , Anti-glare display
• Webcam: 720P HD camera
• Audio: 
        - AI noise-canceling technology
        - DTS software
        - Hi-Res certification
        - Support Microsoft Cortana near field/Far field
• Giao tiếp mạng: 10/100/1000 Mbps
• Giao tiếp không dây: Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.3 Wireless Card (*Bluetooth version may change with OS version different.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort
        - 3x USB 3.2 Gen 2 Type-A
• Pin: 48WHrs, 3S1P, 3-cell Li-ion
• Kích thước (rộng x dài x cao): 35.9 x 25.6 x 2.28 ~ 2.45 cm (14.13" x 10.08" x 0.90" ~ 0.96")
• Cân nặng: 2.30 Kg (5.07 lbs)
• Hệ điều hành: 
        - Windows 11 Home
        - McAfee 30 days free trial', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (258, 92, N'Dell Gaming G15 5530', 39999000, 71, N'Description: 

Laptop Dell Gaming G15 5530
Chơi theo cách của bạn bất kể bạn là ai hay bạn thích gì. Tận hưởng một chiếc máy tính xách tay có phong cách cổ điển, hiện đại khi bạn tiến lên vị trí dẫn đầu bảng xếp hạng. Tùy chỉnh giao diện máy tính xách tay của bạn bằng cách kiểm soát ánh sáng của các tùy chọn bàn phím một vùng và bốn vùng.

Tăng tốc cho trò chơi của bạn
Sẵn sàng cho trận chiến chỉ trong vài giây với một nút bấm, không cần phải thoát game. Nút F9 cũng là phím macro Game Shift, giúp quạt hoạt động tối đa công suất. CPU tự động phát hiện và chuyển sang Chế độ Hiệu suất Động, cung cấp sức mạnh cần thiết để vượt qua những tình huống khó khăn trong game hoặc hoàn thành các tác vụ yêu cầu CPU cao.

Hiệu suất toàn diện
Những game nặng nhất chạy mượt mà với bộ vi xử lý Intel® Core™ mới nhất cùng GPU mạnh mẽ NVIDIA® GeForce RTX™ dành cho laptop. Chơi game mượt mà và không giật lag với bộ nhớ DDR5 lên đến 32GB và dung lượng lưu trữ nội bộ lên đến 2TB.

Giữ bình tĩnh trong những khoảnh khắc quan trọng
Thiết kế tản nhiệt tiên tiến, lấy cảm hứng từ Alienware với bốn ống dẫn nhiệt và quạt cải tiến có cánh siêu mỏng giúp tăng diện tích trao đổi nhiệt. Ngoài ra, còn có sẵn với các cấu hình đồ họa chọn lọc, vật liệu giao diện nhiệt Vapor Chamber và Element 31 kết hợp để giữ cho máy tính xách tay luôn mát mẻ ngay cả trong những phân đoạn hỗn loạn nhất trong trò chơi.


Hoàn hảo cho việc kiểm soát toàn bộ
Kiểm soát  với công nghệ hoàn toàn mới - Alienware Command Center.

Trải nghiệm game cùng Game pass
Chơi game với đồ họa bạn cần, với những người bạn muốn, với các thiết bị ngoại vi bạn thích.
Dù bạn chọn phần nào, Windows 11 đều có phần mềm tận dụng tối đa chúng để mang lại trải nghiệm tốc độ khung hình cao, độ phân giải cao mà bạn mong muốn.
Rất có thể trò chơi bạn muốn chơi tương thích với Windows. Với PC Game Pass, bạn còn có thể thử nhiều thứ hơn nữa—đặc biệt là những tựa game mới nhất vào ngày phát hành.


Detailed Specifications: 


• Hãng sản xuất: Dell
• Chủng loại: Gaming G15 5530
• Part Number: G15-5530-i7HX161W11GR4060
• Mầu sắc: Xám (Dark Shadow Grey)
• Bộ vi xử lý: Intel Core i7 13650HX
• Bộ nhớ trong: 16GB DDR5 4800Mhz (2*8GB)
• Số khe cắm: 2
• VGA: Nvidia Geforce RTX 4060 8G DDR6
• Ổ cứng: 1TB SSD M.2 PCIe NVMe (+ M.2 SSD 2230/2280 slot)
• Ổ quang: No
• Card Reader: SD Card
• Bảo mật, công nghệ: 4-Zone RGB Backlit Keyboard with Numeric Keypad and G-Key
• Màn hình: 15.6" FHD (1920x1080) 165Hz, 3ms, sRGB-100%, ComfortViewPlus, NVIDIA GSYNC+ DDS Display
• Webcam: HD camera
• Giao tiếp mạng: Gigabit
• Giao tiếp không dây: Intel Wi-Fi 2x2 (Gig+) and Bluetooth 5.2
• Cổng giao tiếp: 
        - One RJ-45 port
        - ● Three USB 3.2 Gen 1 ports
        - ● One USB 3.2 Gen 2 (Type-C) with DisplayPort
        - ● One Universal headset jack
        - ● One HDMI 2.1 port
• Pin: 6 cell (86Whr)
• Cân nặng: 2.65kg
• Hệ điều hành: Win 11 Home + Office Home & Student 2021
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (259, 93, N'Lenovo Legion 5 16IRX9', 39999000, 29, N'Description: 

Hiệu năng mạnh mẽ
Được trang bị bộ vi xử lý Intel Core i7-14650HX thế hệ mới với 14 nhân 20 luồng, xung nhịp tối đa lên đến 5.2GHz, mang đến hiệu năng vượt trội cho các tác vụ nặng như chơi game, chỉnh sửa video, render 3D, lập trình,...
Card đồ họa NVIDIA GeForce RTX 4060 8GB GDDR6 thế hệ mới mạnh mẽ, hỗ trợ Ray Tracing và DLSS cho đồ họa chân thực và mượt mà, đáp ứng tốt nhu cầu chơi game AAA ở cài đặt cao hoặc cao nhất.
RAM 16GB DDR5 bus 4800MHz cho khả năng đa nhiệm mượt mà, xử lý nhiều ứng dụng cùng lúc mà không bị lag giật.
Ổ cứng SSD 512GB PCIe NVMe tốc độ cao giúp khởi động máy và truy cập dữ liệu nhanh chóng.

Màn hình chất lượng cao
Màn hình 16 inch WQXGA (2560 x 1600) IPS với tần số quét 165Hz, mang đến hình ảnh sắc nét, chi tiết và chuyển động mượt mà, lý tưởng cho cả chơi game và xem phim.
Tấm nền IPS cho góc nhìn rộng và độ chính xác màu sắc cao, đảm bảo chất lượng hình ảnh tốt từ mọi góc độ.
Hỗ trợ Dolby Vision™ cho hình ảnh HDR sống động với dải màu rộng và độ tương phản cao.
Công nghệ G-SYNC® giúp loại bỏ hiện tượng xé hình và nhiễu hình khi chơi game.

Thiết kế hiện đại
Vỏ máy được làm từ nhôm cao cấp, cho cảm giác sang trọng và chắc chắn.
Kiểu dáng hầm hố, đậm chất game thủ với hệ thống đèn LED RGB tùy chỉnh.
Bàn phím full-size với hành trình phím sâu, độ nảy tốt và đèn nền RGB, mang lại trải nghiệm gõ phím thoải mái và chính xác.
Trackpad lớn, mượt mà, hỗ trợ nhiều cử chỉ đa ngón.
Hệ thống tản nhiệt hiệu quả với 2 quạt lớn và khe hút gió giúp máy luôn mát mẻ khi hoạt động ở hiệu suất cao.

Thời lượng pin
Pin 80Wh cho thời lượng sử dụng pin lên đến 6-7 tiếng khi sử dụng các tác vụ văn phòng cơ bản.

Kết nối đa dạng
Wi-Fi 6E thế hệ mới cho tốc độ kết nối internet nhanh và ổn định.
Bluetooth 5.2 cho khả năng kết nối không dây với các thiết bị ngoại vi như tai nghe, chuột,...
Cổng Thunderbolt™ 4 đa năng cho tốc độ truyền dữ liệu lên đến 40Gbps và hỗ trợ xuất hình ảnh ra màn hình ngoài.
Cổng HDMI 2.1 cho khả năng xuất hình ảnh chất lượng cao lên TV hoặc màn hình ngoài.
Cổng USB Type-C và USB Type-A để kết nối với các thiết bị ngoại vi khác.


Detailed Specifications: 


• Hãng sản xuất: Lenovo
• Chủng loại: Lenovo Legion 5
• Part Number: 83DG004YVN
• Mầu sắc: Xám
• Chất liệu: Aluminium (Top), PC-ABS (Bottom)
• Bộ vi xử lý: I7 14650HX
• Chipset: Intel HM770 Chipset
• Bộ nhớ trong: 2x8GB SO-DIMM DDR5-5600
• Số khe cắm: Two DDR5 SO-DIMM slots, dual-channel capable
• Dung lượng tối đa: Up to 32GB DDR5-5600 offering
• VGA: NVIDIA GeForce RTX 4060 8GB GDDR6, Boost Clock 2370MHz, TGP 140W
• Ổ cứng: 
        - 512GB SSD M.2 2280 PCIe 4.0x4 NVMe,Up to two drives, 2x M.2 SSD
        - M.2 2280 SSD up to 1TB, Two M.2 2280 PCIe 4.0 x4 slots
• Ổ quang: None
• Card Reader: 4-in-1 Card Reader
• Màn hình: 16" WQXGA (2560x1600) IPS 500nits Anti-glare, 100% DCI-P3, 240Hz, DisplayHDR 400, Dolby Vision, G-SYNC, Low Blue Light, High Gaming Performance
• Webcam: FHD 1080p with E-shutter
• Audio: High Definition (HD) Audio, Realtek ALC3306 codec
• Giao tiếp mạng: 100/1000M (RJ-45)
• Giao tiếp không dây: Wi-Fi 6, 11ax 2x2 + BT5.1
• Cổng giao tiếp: 
        - ·  1x USB-A (USB 5Gbps / USB 3.2 Gen 1), Always On
        - ·  3x USB-A (USB 5Gbps / USB 3.2 Gen 1)
        - ·  1x USB-C (USB 10Gbps / USB 3.2 Gen 2), with PD 140W and DisplayPort 1.4
        - ·  1x USB-C (Thunderbolt 4 / USB4 40Gbps), with DisplayPort 1.4
        - ·  1x HDMI 2.1, up to 8K/60Hz
        - ·  1x Headphone / microphone combo jack (3.5mm)
        - ·  1x Ethernet (RJ-45)
        - ·  1x Power connector
• Pin: Integrated 80Wh
• Kích thước (rộng x dài x cao): 363.5 x 262.1 x 21.95-25.9 mm (14.31 x 10.32 x 0.86-1.02 inches)
• Cân nặng: Less than 2.55 kg (5.6 lbs)
• Hệ điều hành: Windows 11 Home Single Language, English', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (260, 89, N'Asus Gaming ROG Strix G614JV-N4156W', 41999000, 11, N'Description: 

LÀM CHỦ CUỘC CHƠI CÙNG ROG STRIX G614JV

HIỆU NĂNG TUYỆT ĐỈNH

CÔNG NGHỆ TẢN NHIỆT THÔNG MINH

MÀN HÌNH SẮC NÉT CÙNG TỐC ĐỘ CAO CHUẨN

THIẾT KẾ ĐỂ CHINH PHỤC TẤT CẢ

LED RGB SIÊU NỔI BẬT

ÂM THÀNH VÒM CÙNG CÔNG NGHỆ CHỐNG ỒN

HOẠT ĐỘNG BỀN BỈ CẢ NGÀY DÀI CÙNG ROG STRIX

ĐẦY ĐỦ CÁC CỔNG KẾT NỐI

TRUY CẬP KHÔNG GIỚI HẠN


Detailed Specifications: 


• Hãng sản xuất: Asus
• Chủng loại: ROG Strix G16
• Part Number: 90NR0C61-M011S0
• Mầu sắc: Eclipse Gray
• Bộ vi xử lý: 13th Gen Intel Core i7-13650HX Processor 2.6 GHz 24M  Cache, up to 4.9 GHz, 14 cores: 6 P-cores and 8 E-cores)
• Chipset: Mobile Intel HM770 Express Chipsets
• Bộ nhớ trong: N/A
• Dung lượng tối đa: DDR5 16GB
• VGA: Intel UHD Graphics
• Ổ cứng: 512GB PCIe 4.0 NVMe M.2 SSD
• Expansion Slot(includes used): 
        - 2x DDR5 SO-DIMM slots
        - 2x PCIe
• M.2 SSD Support List: 512G/ 1TB /2TB G4x4 PCIe SSD
• M.2 slots support either SATA or NVMe: 2
• Bảo mật, Công nghệ: 
        - BIOS Administrator Password and User Password Protection
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 
        - 16-inch
        - QHD+ 16:10 (2560 x 1600, WQXGA)
• Webcam: 720P HD camera
• Audio: 1x 3.5mm Combo Audio Jack
• Giao tiếp mạng: 10/100/1000 Mbps
• Giao tiếp không dây: Wi-Fi 6E(802.11ax) (Triple band) 2*2 + Bluetooth 5.3 Wireless Card (*Bluetooth version may change with OS version different.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x Thunderbolt 4 support DisplayPort
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC
        - 2x USB 3.2 Gen 2 Type-A
• Pin: 90WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 26.4 x 2.26 ~ 3.04 cm (13.94" x 10.39" x 0.89" ~ 1.20")
• Cân nặng: 2.50 Kg (5.51 lbs)
• Hệ điều hành: 
        - Windows 11 Home
        - 1-month trial for new Microsoft 365 customers. Credit card required.', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (261, 89, N'Asus Gaming TUF FA507NV-LP061W', 27599000, 61, N'Description: 

PHONG CÁCH MỚI MẺ

BÀN PHÍM THIẾT KẾ TỐI ƯU HƠN

HIỆU NĂNG MẠNH MẼ

TẢN NHIỆT TỐI ĐA HIỆU QUẢ

MÀN HÌNH CHÂN THỰC - SẮC NÉT

CỔNG KẾT NỐI ĐA DẠNG

HOẠT ĐỘNG BỀN BỈ

ÂM THANH XUẤT SẮC

ĐỘ BỀN CHUẨN QUÂN ĐỘI MỸ

TRẢI NGHIỆM MỌI LOẠI GAME CÙNG PC GAME PASS


Detailed Specifications: 


• Hãng sản xuất: Asus
• Chủng loại: ASUS TUF Gaming A15
• Part Number: FA507NV-LP061W
• Mầu sắc: Jaeger Gray
• Bộ vi xử lý: AMD Ryzen 7 7735HS Mobile Processor (8-core/16-thread, 16MB L3 cache, up to 4.7 GHz max boost)
• Chipset: N/A
• Dung lượng tối đa: DDR5 16GB
• VGA: NVIDIA GeForce RTX 4060 Laptop GPU
• Ổ cứng: 1TB PCIe 4.0 NVMe M.2 SSD
• Expansion Slot(includes used): 2x DDR5 SO-DIMM slots
• M.2 SSD Support List: 
        - M.2 PCIe 512GB
        - M.2 PCIe 1TB
        - M.2 PCIe 2TB
• M.2 slots support either SATA or NVMe: 2
• Bảo mật, Công nghệ: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 
        - 15.6-inch
        - FHD (1920 x 1080) 16:9
        - 144Hz
• Webcam: 720P HD camera
• Audio: 1x 3.5mm Combo Audio Jack
• Giao tiếp mạng: 10/100/1000 Mbps
• Giao tiếp không dây: 
        - Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.3 Wireless Card (*Bluetooth version may change with OS version different.)
        - Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.2 Wireless Card (*Bluetooth version may change with OS upgrades.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x Type C USB 4 support DisplayPort
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC
        - 2x USB 3.2 Gen 1 Type-A
• Pin: 90WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 25.1 x 2.24 ~ 2.49 cm (13.94" x 9.88" x 0.88" ~ 0.98")
• Cân nặng: 2.20 Kg ( lbs)
• Hệ điều hành: Windows 11 Home', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (262, 89, N'Asus Gaming ROG Zephyrus GU605MI-QR116W', 72999000, 37, N'Description: 

Hiệu năng mạnh mẽ và đột phá
Chơi game và sáng tạo nội dung dễ dàng trên hệ điều hành Windows 11 Home. Chiếc Laptop gaming ROG Nebula OLED mạnh nhất này được trang bị bộ xử lý lên đến Intel® Core™ Ultra 9 185H kèm theo vi xử lý đồ họa tích hợp công nghệ AI - NVIDIA® GeForce RTX™ 4060, ROG Zephyrus G16 có thể dễ dàng xử lý mượt mà các trò chơi và các phần mềm sáng tạo mới nhất, nặng nề nhất. Cho dù bạn đang thực hiện cuộc gọi video, biên tập video hay chơi game, các tính năng tăng tốc bằng thuật toán AI sẽ luôn hoạt động liên tục nhằm tối ưu trải nghiêm của bạn. Nhờ có GPU GeForce RTX sở hữu nhân Tensor xử lý AI chuyên dụng cung cấp hiệu năng vượt trội mọi lúc mọi nơi.

Màn hình 2.5K ROG Nebula OLED
Laptop đầu tiên của ROG được trang bị màn hình OLED với tốc độ phản hồi chớp nhoáng và độ tương phản siêu ấn tượng. Màn hình OLED sở hữu độ phân giải 2.5K, cho mật độ pixel cực cao trên màn hình 16 inch với tần số quét 240Hz biến mọi tựa game thành những thước phim đã mắt và lôi cuốn. Công nghệ HDR với độ phủ màu 100% DCI-P3 với chứng nhận VESA HDR True Black 500 mang đến hình ảnh chân thực, sống động đến từng chi tiết. Đắm chìm trong thế giới giải trí với màn hình OLED, nơi mọi nội dung đều được hiển thị một cách hoàn hảo, đánh thức mọi giác quan của bạn.
*Kết quả thử nghiệm trung bình ở MyASUS/ Ứng dụng Armoury Splendid Display P3 và dải màu sRGB: Delta E

Các phím điều khiển chuẩn xác hơn
ROG Zephyrus G16 là chiếc laptop Gaming 16 inch hiếm hoi được trang bị trackpad kích thước rất lớn với tỷ lệ tương đương 16:10. Ngoài ra máy cũng được gia tăng kích thước keycap lên 12%. Tất cả những đặc tính trên nhằm phục vụ cho nhu cầu soạn thảo văn bản với bàn phím và thao tác đa điểm trên trackpad được thoải mái và chính xác tuyệt đối. Thêm vào đó độ cứng của phím cũng được nâng tầm nhờ công nghệ chế tác CNC. Hành trình phím đạt 1,7mm mang lại cho bàn phím cảm giác gõ cực kỳ ổn định, cao cấp, tuổi thọ phím lên đến 20 triệu lần nhấn, hoàn hảo cho mọi nhu cầu với độ bền cực cao.

Âm thanh cải tiến hoàn hảo
Loa trầm cải tiến trên ROG Zephyrus G16 mang đến trải nghiệm âm thanh bùng nổ, nâng tầm mọi cuộc vui. Âm lượng tăng 47% kết hợp cùng tần số âm trầm siêu thấp 100Hz cho âm thanh sống động đến bất ngờ, thách thức mọi giới hạn của một chiếc laptop 16 inch siêu mỏng. Dù đắm chìm trong thế giới âm nhạc với kênh podcast yêu thích hay hòa mình vào những trận chiến game đầy kịch tính, ROG Zephyrus G16 luôn sẵn sàng khuấy động mọi giác quan của bạn với âm thanh đỉnh cao, cho bạn trải nghiệm giải trí hoàn hảo.

Dải Slash Lightning độc đáo
Laptop gaming ROG Nebula OLED mạnh nhất - ROG Zephyrus G16 phá vỡ khuôn khổ, cho ra mắt một thiết kế hoàn toàn mới: dải đèn Slash Lighting. Mang thiết kế một đường nổi bật chạy chéo theo nắp máy, Slash Lighting là định nghĩa tiếp theo cho sự thanh lịch và bản sắc cá nhân, khiến ROG Zephyrus G16 trở nên độc nhất. Thiết kế này giữ lại khả năng tùy chỉnh của mẫu tiền nhiệm, lấy cảm hứng từ khoa học viễn tưởng và nghệ thuật đương đại.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Chủng loại: ROG Zephyrus G16
• Part Number: GU605MI-QR116W
• Mầu sắc: Eclipse Gray
• Bộ vi xử lý: Intel Meteor Lake i9-14***H
• Chipset: N/A
• Dung lượng tối đa: LPDDR5X 32GB
• VGA: NVIDIA GeForce RTX 4070 Laptop GPU
• Ổ cứng: 1TB PCIe 4.0 NVMe M.2 SSD
• Expansion Slot(includes used): 2x PCIe
• M.2 SSD Support List: 
        - 512GB M.2 NVMe PCIe 4.0 SSD
        - 1TB M.2 NVMe PCIe 4.0 SSD
        - 2TB M.2 NVMe PCIe 4.0 SSD
• M.2 slots support either SATA or NVMe: 2
• Màn hình: 16-inch
• : 
        - 2.5K (2560 x 1600, WQXGA) 16:10 aspect ratio
        - 240Hz
• Webcam: 1080P FHD IR Camera for Windows Hello
• Audio: 1x 3.5mm Combo Audio Jack
• Giao tiếp mạng: N/A
• Pin: 90WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 24.6 x 1.49 ~ 1.64 cm (13.94" x 9.69" x 0.59" ~ 0.65")
• Cân nặng: 1.85 Kg (4.08 lbs)
• Hệ điều hành: Windows 11 Home
• Phụ kiện đi kèm: ROG Zephyrus G16 Sleeve (2024)', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (263, 89, N'Asus Gaming TUF FX507ZC4-HN095W', 20999000, 39, N'Description: 

Thiết kế mạnh mẽ, đậm chất gaming
Laptop Asus Gaming TUF FX507ZC4-HN095W nổi bật với thiết kế đơn giản nhưng đầy tinh tế với tông màu xám chủ đạo. Logo TUF nằm chính giữa của nắp máy tạo cảm giác mạnh mẽ, ấn tượng.

Hiệu năng vượt trội giúp bạn chinh phục mọi thử thách
Mặc dù đại diện cho dòng laptop gaming giá rẻ nhưng ASUS TUF Gaming FX507ZC4-HN095W vẫn mang đến hiệu năng đáng kinh ngạc. Với CPU Intel Core i7-12500H giúp máy hoạt động mượt mà khi xử lý nhiều tác vụ yêu cầu cấu hình cao.
GPU GeForce RTX 3050 tích hợp cùng công nghệ MUX Switch làm tăng tốc độ phản hồi, mang đến hình ảnh mượt mà khi sử dụng các phần mềm đồ họa như chơi game, thiết kế.
RAM 16GB mạnh mẽ, cho phép mở nhiều trình duyệt cùng lúc. Đồng thời có thể nâng cấp và mở rộng dung lượng RAM linh hoạt với 2 khe cắm RAM. Ổ cứng SSD 512GB M.2 PCle Gen 4 cho khả năng truy xuất dữ liệu nhanh và mượt, không gian lưu trữ dữ liệu lớn.

Màn hình sắc nét, đồ họa chân thực
ASUS TUF Gaming FX507ZC4-HN095W được trang bị màn hình 15.6 inch Full HD (1920 x 1080), với tấm nền IPS chất lượng cao cho màu sắc chân thực, rõ nét. Tần số quét 144Hz cho màn hình phản hồi nhanh chóng, giảm thiểu tình trạng trễ hình, xé hình, mang lại trải nghiệm game mượt mà, khả năng tương tác chính xác.

Phím sâu, phản hồi nhanh
Bàn phím được thiết kế fullsize cùng đèn LED RGB có thể tùy chỉnh giúp tạo ra những hiệu ứng ánh sáng độc đáo, phù hợp với nhiều phong cách, tạo hứng thú cho bạn khi chơi game.
Cụm phím WASD được làm nổi bật cùng 4 phím mũi tên được thiết kế thụt xuống, tránh khả năng bấm nhầm, đảm bảo tính chính xác khi thao tác nhân vật trong game.

Âm thanh sống động
ASUS TUF Gaming FX507ZC4-HN095W được trang bị hệ thống loa kép với 4 đường cắt lớn cho âm thanh phát ra mạnh mẽ, tạo cảm giác đắm chìm khi thưởng thức âm nhạc, xem phim hay giải trí. Công nghệ DTS:X Ultra và chế độ âm thanh vòm 7.1 cung cấp âm thanh rõ ràng, sống động, giúp bạn cảm nhận âm thanh chân thực trong các trò chơi.

Hệ thống tản nhiệt hiệu quả
ASUS TUF Gaming FX507ZC4-HN095W sở hữu hệ thống làm mát toàn diện với 2 quạt, 84 cánh hoạt động nhanh chóng nhằm tăng cường luồng không khí và làm mát các bộ phận bên trong. 5 ống dẫn nhiệt cùng 4 khe thoát hơi giúp đẩy luồng khí nóng thoát ra ngoài hiệu quả hơn, giúp duy trì nhiệt độ máy ổn định ngay cả khi đang chơi các tựa game nặng nhất.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: FX507ZC4-HN095W
• Bộ vi xử lý: 12th Gen Intel Core i5-12500H Processor 2.5 GHz (18M Cache, up to 4.5 GHz, 12 cores: 4 P-cores and 8 E-cores)
• Chipset: N/A
• Bộ nhớ trong: DDR4 16GB (2*8GB)
• Expansion Slot(includes used): 2x DDR4 SO-DIMM slots
• Dung lượng tối đa: 32GB
• VGA: NVIDIA GeForce RTX 3050 Laptop GPU
• Ổ cứng: 512GB PCIe 3.0 NVMe M.2 SSD
• Security: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 15.6-inch, FHD (1920 x 1080) 16:9, 144Hz refresh rate, 45% NTSC, 62.5% SRGB, Anti-glare Display
• Webcam: 720P HD camera
• Audio: 
        - AI noise-canceling technology
        - Dolby Atmos
        - Hi-Res certification
        - Built-in array microphone
• Giao tiếp không dây: Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.2 (*Bluetooth version may change with OS version different.)
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x Thunderbolt 4 support DisplayPort
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort / G-SYNC
        - 2x USB 3.2 Gen 1 Type-A
        - 1x HDMI 2.1 TMDS
        - 1x 3.5mm Combo Audio Jack
• Pin: 56WHrs, 4S1P, 4-cell Li-ion
• Kích thước (rộng x dài x cao): 35.4 x 25.1 x 2.24 ~ 2.49 cm
• Cân nặng: 2.20 kg
• Hệ điều hành: Windows 11 Home
• Included in the Box: N/A', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (264, 89, N'Asus Gaming TUF FA506NC-HN011W', 17999000, 20, N'Description: 

Thiết kế đậm chất gaming
Máy được trang bị bộ vi xử lý AMD Ryzen™ 5 7535HS với 6 nhân và 12 luồng, cung cấp hiệu suất mạnh mẽ cho cả công việc và giải trí. Bên cạnh đó, chip đồ họa NVIDIA® GeForce® RTX 3050 giúp tăng cường khả năng xử lý đồ họa và hiệu suất chơi game mượt mà.

Màn hình chiến game cực đỉnh
Tổng thể chiếc laptop này lên đến 15.6 inch nên phần màn hình máy tính có kích thước lớn là điều dễ hiểu, tấm nền IPS (chống chói 45%) cung cấp độ phân giải 2K và tần số cực khủng là 144HZ, bên cạnh đó với độ sáng và độ phủ màu ổn áp (250 nits, 63% sRGB) khiến hình ảnh/ video game cho ra luôn đảm bảo độ nét sắc nét mà ít bị ảnh hưởng bởi cường độ ánh sáng bên ngoài.

Sức mạnh đến kinh ngạc
Sự kết hợp CPU AMD Ryzen™ 5 7535HS (3.3GHz - 4.55 GHz) và chiếc card đồ họa NVIDIA® GeForce RTX 3050 chính là điểm ưu ái, tuy chưa phải là những chiếc linh kiện cao cấp nhất nhưng sự phối hợp của hai linh kiện máy tính này đem lại đủ để làm bạn thỏa mãn với hầu hết các tựa game quốc dân (FPS, AAA, MOBA…) như: LOL, PUPG, God of war… ở mức Setting cao và có thể là Ultra.

Sự lựa chọn quá phù hợp dành cho game thủ
Có thể nói Laptop ASUS TUF Gaming A15 FA506NC-HN011W là một trong những sản phẩm đáng chú ý trong dòng sản phẩm TUF Gaming của ASUS. Với thiết kế mạnh mẽ và hiệu suất ấn tượng, laptop này được thiết kế đặc biệt để đáp ứng nhu cầu chơi game và làm việc đa nhiệm nặng nề của người dùng.


Detailed Specifications: 


• Hãng sản xuất: Asus
• Chủng loại: FA506NC-HN011W
• Part Number: 90NR0JF7-M001K0
• Mầu sắc: Graphite Black
• Bộ vi xử lý: AMD Ryzen 5 7535HS Processor 3.3GHz (19MB Cache, up to 4.55 GHz, 6 cores, 12 Threads)
• Chipset: TBD
• Tổng bộ nhớ hệ thống: 4GB GDDR6
• Dung lượng tối đa: 32GB
• IGPU: AMD Radeon Graphics
• Ổ cứng: 512GB PCIe 4.0 NVMe M.2 SSD
• Ổ quang: N/A
• VGA: NVIDIA GeForce RTX 3050 Laptop GPU
• Khe cắm bộ nhớ: 2x SO-DIMM slots
• Cổng hỗ trợ M.2 SSD: 
        - M.2 512GB G4x4 PCIe SSD
        - M.2 1TB G4x4 PCIe SSD
• Bảo mật, Công nghệ: 
        - BIOS Administrator Password and User Password Protection
        - Kensington Security Slot
        - Trusted Platform Module (Firmware TPM)
• Màn hình: 15.6-inch, FHD (1920 x 1080) 16:9,NTSC:45%,SRGB:62,5% , Brightness :250 nits
• Wifi / Bluetooth: Wi-Fi 6(802.11ax) (Dual band) 2*2 + Bluetooth 5.3 Wireless Card (*Bluetooth version may change with OS version different.)
• Audio Tech: 
        - AI noise-canceling technology
        - DTS software
        - Hi-Res certification
        - Support Microsoft Cortana near field/Far field
• Hiển thị đầu ra: 1x HDMI 2.0b
• Webcam: 720P HD camera
• Loại bàn phím: Backlit Chiclet Keyboard 1-Zone RGB
• Cổng giao tiếp: 
        - 1x RJ45 LAN port
        - 1x USB 3.2 Gen 2 Type-C support DisplayPort
        - 3x USB 3.2 Gen 1 Type-A
• Pin: 48WHrs, 3S1P, 3-cell Li-ion
• Kích thước (rộng x dài x cao): 35.9 x 25.6 x 2.28 ~ 2.45 cm (14.13" x 10.08" x 0.90" ~ 0.96")
• Trọng lượng: 2.30 Kg (5.07 lbs)
• Power: ø6.0, 180W AC Adapter, Output: 20V DC, 9A, 180W, Input: 100~240V AC, 50/60Hz universal
• Hệ điều hành: Windows 11 bản quyền.
• Phụ kiện đi kèm: Dây sạc, pin sạc, sách hướng dẫn sử dụng', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (265, 94, N'MSI Thin 15', 18990000, 54, N'Description: 

THIẾT KẾ NGOẠI HÌNH
- MSI Thin 15 lấy nhiều cảm hứng từ hai tác phẩm nổi tiếng là "Blade Runner" và "Dune". Nhân vật biểu trưng cho tinh thần của Thin 15 là "C15" - hình mẫu của sự thon gọn, sức mạnh đáng nể và đậm chất Gaming. Thiết kế phần trong suốt trên bàn phím cho phép người dùng nhìn thấy các linh kiện bên trong và những đường viền máy móc đặc trưng, tạo nên một ngôn ngữ thiết kế nhất quán. Chiếc laptop Thin 15 thể hiện phong cách tương lai đầy đặc sắc.
- Về kích thước, máy có 359 x 254 x 21.5 mm (Dài x Rộng x Dày) và nặng 1.85 kg. Được trang bị PIN 53WHrs, đây là dung lượng tiêu chuẩn hiện nay cho dòng laptop gaming. Tính chất thon gọn của MSI Thin 15 cùng hiệu năng chuẩn của một máy gaming khiến nó trở thành lựa chọn lý tưởng cho người dùng muốn sở hữu một chiếc laptop mạnh mẽ mà vẫn tiện dụng và di động.

HIỆU NĂNG VƯỢT TRỘI CỦA CPU INTEL GEN 12TH
- Laptop MSI Thin 15 B12UCX 1416VN được trang bị vi xử lý CPU Intel i5-12450H (8 Cores, 12 Threads) kết hợp VGA NVIDIA GeForce RTX 3050 4GB GDDR6, mang lại hiệu năng cao đồng thời tiết kiệm điện, tối ưu cho cả công việc đa nhiệm và các tác vụ văn phòng, cũng như trải nghiệm giải trí game tuyệt vời. Công nghệ Max-Q cũng được tích hợp để tối ưu hiệu năng cho các tác vụ thích hợp, giúp máy ít toả nhiệt hơn và giảm độ ồn quạt, đạt hiệu suất tổng thể cao nhất.
- Đi kèm với đó, máy trang bị SSD 512GB M.2 PCIe Gen4 với tốc độ truy xuất cực nhanh và dung lượng lớn, cho phép dễ dàng lưu trữ và cài đặt mọi ứng dụng và tăng dung lượng khi cần thiết với 1 slot mở rộng. Đồng thời, RAM 8GB DDR4 3200MHz hiệu suất cao cũng đóng góp vào trải nghiệm hoàn toàn mượt mà hơn, tăng cường khả năng xử lý và đáp ứng nhu cầu công việc và giải trí của người dùng.

MÀN HÌNH NÂNG CAO KHẢ NĂNG LÀM VIỆC GIẢI TRÍ
- MSI Thin 15 B12UC 1416VN sở hữu màn hình 15.6-inch FHD với tấm nền IPS và tần số quét 144Hz, đem lại trải nghiệm hình ảnh sắc nét và mượt mà. Thiết kế hiện đại với viền mỏng và khả năng chống chói giúp tăng thêm không gian trải nghiệm rộng rãi hơn so với các mẫu trước đây, cho phép người dùng thưởng thức hình ảnh sống động và chân thực hơn.
- Đáng chú ý, Thin 15 còn tích hợp webcam chuẩn HD 720P, cho phép người dùng thực hiện học online và tham gia các hoạt động giải trí trực tuyến một cách dễ dàng. Điều này tăng cường tính linh hoạt và tiện ích cho người dùng, giúp họ hoàn thành các công việc học tập và làm việc từ xa một cách thuận tiện và hiệu quả.

BÀN PHÍM ĐƯỢC THIẾT KẾ ĐỘC ĐÁO
- Bàn phím Keyboard của laptop MSI Thin 15 B12UC 1416VN là một thiết kế độc đáo và ấn tượng với cấu trúc xuyên thấu. Trong đó, cụm phím WASD được làm nổi bật bằng đèn Neon, giúp người chơi Game điều khiển trò chơi nhanh chóng và chính xác hơn. Các phím mũi tên, phím cách và phím nguồn cũng được thiết kế theo phong cách cyberpunk, mang đến chất viễn tưởng và hấp dẫn, kết hợp với cảm giác công nghệ tương lai của máy.


Detailed Specifications: 


• Tên sản phẩm: Laptop MSI Thin 15 B12UC 1416VN
• Model: Intel Core i5-12450H Gen 12th
• Xung nhịp: tốc độ tối đa: 4.4GHz
• Số chip: 8 Cores
• Số luồng: 12 Threads
• Bộ nhớ đệm: 12MB Cache
• Dung lượng: 
        - 8GB
        - SSD 512GB M.2
• Công nghệ: 
        - DDR4 3200MHz
        - PCIe Gen4
• VGA tích hợp: Intel Iris Xe Graphics
• VGA chuyên dụng: Nvidia Geforce RTX 3050 4GB GDDR6
• Độ phân giải: 
        - FHD (1920*1080) pixel
        - HD 720P
• tấm nền: IPS
• Độ phủ màu: cập nhật
• Tần số quét: 144Hz
• thông số khác: viền mỏng, chống chói
• Wi-Fi: Wi-Fi 6E 802.11ax
• Bluetooth: Bluetooth 5.3
• LAN: LAN RJ45 Gigabit
• Đọc thẻ: None
• Loa: 2 loa
• Âm thanh: Nahimic, Hi-Res Audio
• Kết nối: Jack Audio 3.5mm
• Bàn phím: Chiclet Keyboard
• Đèn LED: Single LED - Xanh
• Hệ thống tản nhiệt: Cooler Boost
• Số quạt: 1 quạt làm mát
• Ống đồng: 2 ống đồng dẫn nhiệt
• Lỗ thoát khí: 2 lỗ thoát khí
• Pin: 53WHrs Battery
• Trọng lượng: 1.85 kg
• Hệ điều hành: Windows 11 bản quyền
• Màu sắc: Xám Đen (Grey)
• Tình trạng: Mới 100%
• Xuất xứ: Hàng chính hãng MSI Việt Nam', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (266, 94, N'MSI Gaming Sword 16 HX B14VFKG-045VN', 39990000, 30, N'Description: 

Laptop MSI Gaming Sword 16 HX

HIỆU SUẤT CAO NHẤT DÀNH CHO GAME THỦ BỘ XỬ LÝ INTEL ® CORE™ i 7 14700HX
Cho dù bạn đang tham gia các trận chiến hoành tráng trong các tựa game yêu thích của mình, khám phá các thế giới ảo rộng lớn hay truyền trực tuyến lối chơi của mình tới khán giả trên toàn thế giới, bộ xử lý Intel® Core™ i7 mạnh mẽ 14700HX sẽ là người bạn đồng hành chơi game tối ưu, đảm bảo rằng bạn có thể tận hưởng trải nghiệm liền mạch. , chơi game không bị lag và khai thác toàn bộ tiềm năng của thiết bị chơi game của bạn.

MÁY TÍNH XÁCH TAY GEFORCE RTX 40 SERIES TUYỆT VỜI NHANH CHÓNG
GPU máy tính xách tay NVIDIA® GeForce RTX™ 40 Series cung cấp sức mạnh cho máy tính xách tay nhanh nhất thế giới dành cho game thủ và người sáng tạo. Được xây dựng bằng kiến ​​trúc NVIDIA Ada Lovelace cực kỳ hiệu quả, chúng mang lại bước nhảy vọt về hiệu suất với DLSS 3 được hỗ trợ bởi AI và tạo ra các thế giới ảo sống động như thật với tính năng dò tia đầy đủ. Ngoài ra, bộ công nghệ Max-Q tối ưu hóa hiệu suất hệ thống, năng lượng, thời lượng pin và âm thanh để đạt hiệu quả cao nhất.

HÌNH ẢNH TUYỆT VỜI
Với màn hình IPS 240Hz QHD+ bao phủ không gian màu 100% DCI-P3, bạn sẽ mãn nhãn với nội dung sống động sắc nét ở chất lượng mượt mà nhất. Màn hình tỷ lệ vàng 16:10 mở rộng tầm nhìn hơn nữa, mang lại trải nghiệm hình ảnh đỉnh cao.
*Không bắt buộc. Thông số kỹ thuật thực tế có thể thay đổi tùy theo cấu hình.

TỎA SÁNG VỚI PHONG CÁCH CHƠI GAME
Trải nghiệm sự phát triển của máy tính xách tay chơi game với Bàn phím RGB 24 vùng được nâng cấp của Sword Series. Các phím WASD mờ được đắm mình trong màu sắc rực rỡ giúp nâng cao trải nghiệm chơi game. Chiếu sáng thế giới của bạn với phong cách và sự đổi mới.
TRẢI NGHIỆM KHÔNG DÂY TUYỆT VỜI
Wi-Fi 6E mới nhất mang lại tốc độ đáng kinh ngạc đồng thời giữ cho mạng luôn mượt mà và ổn định ngay cả khi chia sẻ mạng với nhiều người dùng.

ĐỊNH DẠNG LẠI ĐỂ LÀM MÁT TỐI ĐA
Lỗ thông hơi làm mát mới với 6 ống xả cho phép luồng khí thoát ra đa hướng để làm mát hiệu quả hơn, cùng với thiết kế ống chung với 5 ống dẫn nhiệt giữa CPU và GPU, đường kính trong của ống dẫn nhiệt lớn hơn và mỡ tản nhiệt độc quyền của MSI để đảm bảo hiệu suất tối đa trong điều kiện chơi game cực độ.


Detailed Specifications: 


• Hãng sản xuất: MSI
• Chủng loại: Sword 16 HX
• Part Number: B14VFKG-045VN
• Mầu sắc: Xám (Cosmos Gray)
• Bộ vi xử lý: ntel Core i7-14700HX
• Chipset: Intel HM770
• Bộ nhớ trong: 16GB DDR5 5600Mhz (8GB *2)
• Số khe cắm: 2
• Dung lượng tối đa: 96GB
• VGA: NVIDIA GeForce RTX 4060 8G GDDR6
• Ổ cứng: 1TB NVMe PCIe Gen4x4
• Ổ quang: No
• Keyboard: 24-Zone RGB Gaming Keyboard
• Màn hình: 16" 16:10 QHD+(2560 x 1600), 240Hz, 100% DCI-P3, IPS-level panel
• Webcam: IR FHD type (30fps@1080p) with HDR
• Audio: Hi-Res Audio
• Giao tiếp mạng: Gigabit LAN
• Giao tiếp không dây: Intel Wi-Fi 6E AX211
• Cổng giao tiếp: 
        - 1x Type-C (USB3.2 Gen2 / DP) with PD charging
        - 3x Type-A USB3.2 Gen1
        - 1x HDMI 2.1 (8K @ 60Hz / 4K @ 120Hz)
        - 1x RJ45
        - 1x 3.5 kết hợp
• Pin: 4cell, 65Wh
• Kích thước (rộng x dài x cao): 315.6 x 246.25 x 19.9-21.8 mm
• Cân nặng: 1.7 kg
• Hệ điều hành: Windows11 Home
• Phụ kiện đi kèm: Cable + sạc', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (267, 93, N'Lenovo Gaming LOQ 15IAX9', 19999000, 34, N'

Detailed Specifications: 


• Hãng sản xuất: Lenovo
• Chủng loại: Lenovo LOQ
• Part Number: 83GS001RVN
• Mầu sắc: Xám
• Chất liệu: Nhựa ABS
• Bộ vi xử lý: Intel Core i5-12450HX, 8C (4P + 4E) / 12T, P-core up to 4.4GHz, E-core up to 3.1GHz, 12MB
• Chipset: Intel HM670 Chipset
• Bộ nhớ trong: 1x 12GB SO-DIMM DDR5-4800
• Số khe cắm: 2
• Số khe RAM chờ: 1
• Dung lượng tối đa: Up to 32GB DDR5-4800
• VGA: NVIDIA GeForce RTX 3050 6GB GDDR6, Boost Clock 1732MHz, TGP 95W
• Ổ cứng: 
        - 512GB SSD M.2 2242 PCIe 4.0x4 NVMe, Up to two drives, 2x M.2 SSD
        - M.2 2242 SSD up to 1TB, Two M.2 2280 PCIe 4.0 x4 slots
• Ổ quang: None
• Card Reader: None
• Bảo mật, công nghệ: Firmware TPM 2.0 Enabled, E-shutter, Stereo speakers, 2W x2, optimized with Nahimic Gaming Audio
• Màn hình: 15.6" FHD (1920x1080) IPS 350nits Anti-glare, 45% NTSC, 144Hz, G-SYNC
• Webcam: FHD 1080p with E-shutter
• Audio: High Definition (HD) Audio, Realtek ALC3287 codec
• Giao tiếp mạng: 100/1000M (RJ-45)
• Giao tiếp không dây: Wi-Fi 6, 11ax 2x2 + BT5.1
• Cổng giao tiếp: 
        - 3x USB-A (USB 5Gbps / USB 3.2 Gen 1)
        - 1x USB-C (USB 10Gbps / USB 3.2 Gen 2), with PD 140W and DisplayPort 1.4
        - 1x HDMI 2.1, up to 8K/60Hz
        - 1x Headphone / microphone combo jack (3.5mm)
        - 1x Ethernet (RJ-45)
        - 1x Power connector
• Pin: 60Wh
• Kích thước (rộng x dài x cao): 359.86 x 258.7 x 21.9-23.9 mm (14.17 x 10.19 x 0.86-0.94 inches)
• Cân nặng: 2.4 kg
• Hệ điều hành: Windows 11 Home Single Language, English
• Phụ kiện đi kèm: Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (268, 95, N'LG Gram 14Z90R-G.AH75A5', 25999000, 20, N'Description: 

LG gram 2023
Lưu ý: Bài viết và hình ảnh chỉ có tính chất tham khảo vì cấu hình và đặc tính sản phẩm có thể thay đổi theo thị trường và từng phiên bản. Quý khách cần cấu hình cụ thể vui lòng liên hệ với các tư vấn viên để được trợ giúp.
Ba màu máy tính xách tay LG gram được xếp theo đường chéo.
*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.


Thân máy gram mỏng và nhẹ mang đến khả năng di động và năng suất.

Siêu nhẹ nhưng siêu mạnh
Laptop mỏng nhẹ cùng với hiệu suất mạnh mẽ, LG gram mang đến cho bạn khả năng di động cao và năng suất làm việc tuyệt vời.
*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.

Thân máy gram đã qua được bài kiểm tra tiêu chuẩn quân sự MIL-STD-810H có đòi hỏi khắt khe về độ bền và độ tin cậy.
Độ bền đã được chứng minh
LG gram đã vượt qua 7 bài kiểm tra độ bền quân sự Mỹ MIL-STD-810H. Được làm từ vật liệu siêu nhẹ nhưng bền - magnesium, laptop LG gram đảm bảo độ mạnh mẽ cũng như tính di động cao.



Màn hình lớn độ phân giải cao
Bạn sẽ bị quyến rũ trước màu sắc sống động và chân thực của hình ảnh hiển thị, bởi vì laptop LG gram được thiết kế với tỷ lệ khung hình 16:10, độ phân giải WQXGA hỗ trợ gam màu rộng DCI-P3 99%, cho phép bạn xem được nhiều nội dung hơn mà không phải cuộn màn hình.



*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
**DCI-P3 Thông thường 99%, Tối thiểu 95%.
DCI-P3: Tiêu chuẩn màu được định nghĩa bởi Sáng kiến Điện ảnh Kỹ thuật số (DCI).
Dễ chịu mắt ngay cả trong ánh sáng cường độ cao
LG gram được trang bị tấm nền IPS chống lóa (Anti-Glare) cùng với độ sáng màn hình lên tới 400 nits, giúp bạn thoải mái làm việc hay thưởng thức các thước phim giải trí ngoài trời hay tại những nơi có cường độ ánh sáng cao.

*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
*Độ sáng là 350 nits (Thông thường).
Dolby Atmos Loa âm thanh vòm
Nghe, cảm nhận nhiều hơn và hòa mình trong âm nhạc hay phim ảnh thông qua loa âm thanh vòm được phát triển bởi Dobly Atmos.

*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
Nâng cấp các công nghệ mới nhất

Máy được trang bị sức mạnh của chip Intel® Core™ thế hệ thứ 13 mới nhất, đáp ứng tất cả các nhu cầu xử lý rất nặng từ chơi game đến công việc sáng tạo.

*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
Intel® Unison™ - Liên kết các thiết bị thật dễ dàng
Với phần mềm Intel® Unison™, giờ đây việc liên kết  từ các thiết bị Android hoặc iOS với gram của bạn thật dễ dàng: chuyển file, gửi tin nhắn, thực hiện cuộc gọi.


Detailed Specifications: 


• Hãng sản xuất: LG
• Chủng loại: LG Gram 14ZD90R (Model 2023)
• Part Number: 14Z90R-G.AH75A5
• Mầu sắc: Đen; Vỏ hợp kim Nano Carbon Magnesium siêu bền
• Bộ vi xử lý: I7-1360P (12 Cores, 1.6Ghz up to 3.7 Ghz/18MB cache)
• Bộ nhớ trong: 16GB LPDDR5 6000MHz Dual channel Non-upgradable
• Số khe cắm: 0
• Dung lượng tối đa: 16GB
• VGA: Intel Iris Xe Graphics
• Ổ cứng: 512GB SSD NVMe Gen4 (thêm 01 khe cắm SSD M2)
• Ổ quang: None
• Bảo mật, Công nghệ: Mega cooling: Backlit Keyboard
• Màn hình: 14.0 inch WUXGA (1920*1200) IPS LCD; chống chói; Tỷ lệ 16:10; Độ phủ màu DCI-P3 99% (Thông thường)
• Webcam: FHD IR Webcam (Nhận diện khuôn mặt Hello Windows)
• Audio: Âm thanh HD với công nghệ âm thanh vòm Dolby Atmos với Stereo Speaker
• Giao tiếp không dây: Intel Wireless-AX211 (802.11ax, 2x2, Dual Band, BT Combo)
• Cổng giao tiếp: HDMI, USB 3.2 Gen2x1 Type A (x2), USB 4 Gen3x2 Type C (x2, with Power Delivery, Display Port, Thunderbolt 4)
• Pin: 72Wh up to 24.5 giờ (Video Playback)
• Kích thước: 31.2 cm x 21.39 cm x 1.68  cm
• Cân nặng: 999g
• Hệ điều hành: Win 11 Home
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (269, 95, N'LG Gram 16Z90R-G.AH76A5', 32999000, 13, N'

Detailed Specifications: 


• Hãng sản xuất: LG
• Chủng loại: LG Gram 16Z90R (Model 2023)
• Part Number: 16Z90R-G.AH76A5
• Mầu sắc: Xám; Vỏ hợp kim Nano Carbon Magnesium siêu bền
• Bộ vi xử lý: I7-1360P (12 Cores 1.6Ghz up to 3.7 Ghz/18MB cache)
• Bộ nhớ trong: 16GB LPDDR5 6000MHz Dual channel Non-upgradable
• Số khe cắm: 0
• Dung lượng tối đa: 16GB
• VGA: Intel Iris Xe Graphics
• Ổ cứng: 512GB SSD NVMe Gen4 (thêm 01 khe cắm SSD M2)
• Ổ quang: None
• Bảo mật, Công nghệ: Mega cooling: Full size Backlit Keyboard
• Màn hình: 16 inch WQXGA (2560*1600) IPS LCD; chống chói; Tỷ lệ 16:10; Độ phủ màu DCI-P3 99% (Thông thường)
• Webcam: FHD IR Webcam (Nhận diện khuôn mặt Hello Windows)
• Audio: Âm thanh HD với công nghệ âm thanh vòm Dolby Atmos với Stereo Speaker
• Giao tiếp không dây: Intel Wireless-AX211 (802.11ax, 2x2, Dual Band, BT Combo)
• Cổng giao tiếp: HDMI, USB 3.2 Gen2x1 Type A (x2), USB 4 Gen3x2 Type C (x2, with Power Delivery, Display Port, Thunderbolt 4)
• Pin: 80Wh up to 23.5 giờ (Video Playback)
• Kích thước: 35.51 cm x 24.23 cm x 1.68 cm
• Cân nặng: 1199g
• Hệ điều hành: Win 11 Home Plus
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (270, 93, N'Lenovo IdeaPad Slim 5 Pro 16ARH7', 21999000, 74, N'

Detailed Specifications: 


• Hãng sản xuất: Lenovo
• Chủng loại: Ideapad 5 pro
• Part Number: 82SN003GVN
• Mầu sắc: Xám
• Chất liệu: Nhôm
• Bộ vi xử lý: AMD Ryzen 7 6800HS Creator Edition
• Chipset: AMD SoC Platform
• Bộ nhớ trong: 16GB
• Số khe cắm: 1
• Số khe RAM chờ: 0
• Dung lượng tối đa: 16GB
• VGA: NVIDIA GeForce RTX 3050Ti 4GB
• Ổ cứng: 512GB SSD M.2 2242 PCIe 4.0x4 NVMe
• Ổ quang: None
• Card Reader: 4-in-1 Card Reader
• Bảo mật, công nghệ: Firmware TPM 2.0, IR camera for Windows Hello, Stereo speakers, 2W x2, optimized with Dolby Atmos
• Màn hình: 16" 2.5K (2560x1600) IPS 350nits Anti-glare, 120Hz, 100% sRGB, TÜV Low Blue Light, G-sync
• Webcam: ToF, FHD 1080p & IR
• Audio: High Definition (HD) Audio, Realtek ALC3287 codec
• Giao tiếp mạng: None
• Giao tiếp không dây: Wi-Fi 6 11ax, 2x2 + BT5.1
• Cổng giao tiếp: 
        - 1x USB 3.2 Gen 1
        - 1x USB 3.2 Gen 1 (Always On)
        - 1x USB-C 3.2 Gen 2 (support data transfer, Power Delivery, and DisplayPort)
        - 1x HDMI 2.0
        - 1x Card reader
        - 1x Headphone / microphone combo jack (3.5mm)
• Pin: 75Wh
• Kích thước (rộng x dài x cao): 356 x 251 x 16.9 mm
• Cân nặng: 1.95 kg
• Hệ điều hành: Win 11 home
• Phụ kiện đi kèm: Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (271, 94, N'MSI Creator Z16', 21990000, 25, N'Description: 

THIẾT KẾ & NGOẠI HÌNH ĐẦY MẠNH MẼ CÁ TÍNH
Laptop MSI Creator Z16 A11UET-217VN là một sự kết hợp tuyệt vời giữa thiết kế với công nghệ hiện đại. Dễ dàng thao tác, điều khiển với màn hình cảm ứng và đặc biệt khi được trang bị rất nhiều công nghệ hiện đại hàng đầu hiện nay.
- Vỏ máy được chế tác từ hợp kim kim loại chất lượng, mang đến vẻ sang trọng đẳng cấp và được hoàn thiện với những đường cắt sắc sảo. Khi bạn đóng máy, không có gì khác biệt với một tác phẩm nghệ thuật, màn hình của MSI Creatior 16 có kích thước: 359 x 256 x 15.9 mm (Dài x Rộng x Dày), trọng lượng 2.2kg và viên PIN 90WHrs. Sự hòa quyện giữa hình dáng tinh tế và sự cẩn trọng trong từng chi tiết tạo nên một sản phẩm không chỉ thực sự độc đáo mà còn đầy tính nghệ thuật, đơn giản là một tác phẩm điêu khắc mà bạn có thể mang theo bất cứ nơi đâu.

Tăng tốc cho công việc sáng tạo RTX 30 series mới nhất.
Bạn có thể tưởng tượng ra được điều gì thì những chiếc laptop đạt chuẩn NVIDIA Studio trang bị GPU GeForce RTX 30 Series đều có thể giúp bạn biến nó thành tác phẩm thật sự. Với hiệu năng dựng hình cao gấp 2 lần và bộ nhớ đồ họa cao hơn gấp đôi so với 20 Series, các tác vụ như biên tập video 8K HDR RAW hay làm việc với các mô hình 3D cỡ lớn đều sẽ được xử lí trôi chảy hơn bao giờ hết. Đó là chưa kể hiệu năng cao hơn khi sử dụng pin để làm việc di động, cùng màn hình chất lượng với độ chính xác màu cao, hiển thị rõ từng chi tiết nhỏ nhất, nay đã có thêm tùy chọn độ phân giải 1440p. Tăng tốc cho công việc sáng tạo nội dung của bạn nhờ ứng dụng công nghệ AI tiên tiến trên các ứng dụng sáng tạo phổ biến, giúp xử lí mọi tác vụ trong thời gian cực ngắn.

Màn hình tỉ lệ vàng đầy trực quan
Tỉ lệ màn hình 16:10 gần tương đồng với Tỉ lệ vàng 1.618, con số thần thánh được coi là biểu trưng của cái đẹp. Tỉ lệ màn hình này cho diện tích hiển thị nhiều hơn 11% so với tỉ lệ 16：9, thuận tiện hơn để xem timeline hay khu vực làm việc trên các ứng dụng của Adobe. Với triết lí thiết kế xoay quanh con người, Creator Z16 được trang bị màn hình cảm ứng để giúp tương tác trực quan hơn, cho phép dễ dàng thiết kế các tác phẩm phức tạp.

Trải nghiệm không dây hoàn hảo
Chuẩn Wi-Fi 6E mới nhất cho tốc độ đáng kinh ngạc trong khi vẫn đảm bảo kết nối mượt mà ổn định ngay cả khi có nhiều người cùng sử dụng. Với băng thông cực cao và độ trễ thấp, bạn sẽ luôn có được kết nối không dây tốt nhất.

Phá vỡ mọi ranh giới Creator
Z16 cung cấp pin lâu dài 90Whr và công nghệ sạc nhanh thích ứng với cách bạn làm việc tốt hơn bao giờ hết. Tay nghề thủ công của Creator Z16 định nghĩa tính thẩm mỹ và khoa học nhân văn. Được chế tạo bằng khung kim loại siêu mỏng 15,9mm, Creator Z16 nâng cao năng suất của bạn mọi lúc, mọi nơi.


Detailed Specifications: 


• CPU: Intel Core i7-11800H 8 nhân 16 luồng
• RAM: 32GB (2 x 16 GB) DDR4 3200MHz (2x SO-DIMM socket, up to 64GB SDRAM)
• Ổ cứng: 1TB M.2 NVMe PCIe Gen4x4
• Card đồ họa: NVIDIA GeForce RTX 3060, 6GB GDDR6
• Màn hình: 16 inch QHD+ (2560*1600), 120Hz DCI-P3 100% typical, Finger Touch panel
• Cổng giao tiếp: 
        - 1x Micro SD
        - 2x Type-A USB3.2 Gen2
        - 2x Type-C (USB / DP / Thunderbolt 4)
        - 1x Mic-in/Headphone-out Combo Jack
• Audio: Nahimic 3 / Hi-Res Audio, Dynaudio Speakers 2W*4
• Bàn phím: Per key RGB MiniLED keyboard by Steelseries
• Chuẩn WIFI: Killer ax Wi-Fi 6E (802.11ax)
• Bluetooth: v5.2
• Webcam: IR HD type (30fps@720p)
• Hệ điều hành: Windows 10 Home
• Pin: 90 Whr
• Trọng lượng: 2.2 kg
• Kích thước: 359 x 256 x 15.9 mm', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (272, 89, N'Asus VivoBook K6502VU-MA090W', 38999000, 19, N'Description: 

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W

Laptop Asus VivoBook K6502VU-MA090W


Detailed Specifications: 


• Hãng sản xuất: Asus
• Part Number: K6502VU-MA090W
• Bộ vi xử lý: Intel Core i9-13900H Processor 2.6 GHz (24MB Cache, up to 5.4 GHz, 14 cores, 20 Threads)
• Chipset: N/A
• Bộ nhớ trong: 8GB DDR5 on board
• Số khe cắm: 
        - 1x DDR4 SO-DIMM slot
        - 1x M.2 2280 PCIe 4.0x4
• Dung lượng tối đa: 16GB
• VGA: on
• Ổ cứng: 512GB M.2 NVMe PCIe 4.0 SSD
• M.2 SSD Support List: support PCIE Gen4x4 & Gen3x4
• Expansion Slot(includes used): 2x DDR5 SO-DIMM slots
• Màn hình: 15.6-inch
• , Webcam: 720p HD camera ; With privacy shutter
• Giao tiếp mạng: 10/100/1000/2500 Mbps
• Giao tiếp không dây: 10/100/1000/Gigabits Base T
• Cổng giao tiếp: Wi-Fi 6E(802.11ax) (Dual band) 2*2 + Bluetooth 5
• Pin: 70WHrs, 3S1P, 3-cell Li-ion
• Kích thước (rộng x dài x cao): 35.63 x 23.53 x 1.99 ~ 2.00 cm
• Cân nặng: 1.80 kg
• Hệ điều hành: Windows 11 Home', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (273, 94, N'MSI Creator Z16 HX Studio', 84990000, 28, N'Description: 

THIẾT KẾ & NGOẠI HÌNH ĐẦY MẠNH MẼ CÁ TÍNH

Dành cho những người đam mê sự sáng tạo và luôn tìm kiếm những trải nghiệm mới mẻ, MSI Creator Z16 đã sẵn sàng để làm thỏa mãn mọi nhu cầu của người dùng. Với thiết kế độc đáo, máy mang trong mình sự tỉ mỉ và vẻ đẹp thẩm mỹ cao cấp, mở ra một kỷ nguyên mới của công nghệ và thẩm mỹ.
- Vỏ máy được chế tác từ hợp kim kim loại chất lượng, mang đến vẻ sang trọng đẳng cấp và được hoàn thiện với những đường cắt sắc sảo. Khi bạn đóng máy, không có gì khác biệt với một tác phẩm nghệ thuật, màn hình của MSI Creatior Z16 có kích thước: 359 x 256 x 18.5 mm (Dài x Rộng x Dày), trọng lượng 2.35kg và viên pin 90WHrs. Sự hòa quyện giữa hình dáng tinh tế và sự cẩn trọng trong từng chi tiết tạo nên một sản phẩm không chỉ thực sự độc đáo mà còn đầy tính nghệ thuật, đơn giản là một tác phẩm điêu khắc mà bạn có thể mang theo bất cứ nơi đâu.
HIỆU NĂNG SIÊU VƯỢT TRỘI

Khi nói đến hiệu năng, chỉ một từ "hoàn hảo" là không đủ để diễn tả sự ấn tượng của MSI Creator Z16 HX B13VGTO 062VN. Máy thực sự không để lại lỗ hỏng nào trong việc nâng cấp cấu hình. Mọi thông số đều thể hiện rằng đây là một chiếc laptop có khả năng vận hành mượt mà với mọi phần mềm thiết kế đồ họa, thậm chí cả những tựa game AAA cũng không thể làm cho chiếc laptop này trễ hơn.
Máy sử dụng CPU Intel i9-13950HX (24 Cores, 32 Threads) Gen 13th siêu khủng và card đồ họa VGA Nvidia Geforce RTX 4070 8GB GDDR6 cùng với Intel® Iris Xe Graphics, mang đến hiệu suất vượt trội cho những người yêu thích sáng tạo nội dung chuyên nghiệp. RAM 64GB DDR5 5600MHz với 2 khe cắm và ổ cứng SSD 2TB M.2 PCle Gen5 hỗ trợ tốc độ phản hồi cực nhanh. Mọi công việc được thực hiện một cách nhanh chóng, mượt mà và hiệu quả, tạo nên một trải nghiệm làm việc và giải trí đỉnh cao mà bạn chưa từng trải qua.
MÀN HÌNH CẢM ỨNG 2K TẦN SỐ LÀM MỚI LÊN ĐẾN 120Hz

Màn hình của Creator Z16 không chỉ là một phần của máy, mà còn là nguồn cảm hứng và công cụ để hiện thực hóa những ý tưởng tưởng chừng như không thể. Với màn hình True Pixel chất lượng cao, nó mang đến không gian cho những hình ảnh sống động và chân thật. Độ phân giải QHD+ cùng với 100% DCI-P3 và chỉ số Delta-E , kết hợp với công nghệ True Color, đảm bảo rằng màu sắc được hiển thị trên màn hình là sự trung thực tuyệt đối. Ngoài ra, webcam HD 720P cũng được tích hợp trong chiếc laptop này, bạn có thể thoải mái meeting hay call video mà không lo chất lượng hình ảnh từ webcam.
Tính năng màn hình cảm ứng Touchsreen và hỗ trợ MSI Pen Touch (tuỳ phiên bản) là những điểm nổi bật khác mà Creator Z16 mang đến. Chúng tạo ra một trải nghiệm tương tác trực quan, giúp bạn dễ dàng tạo ra những tác phẩm phức tạp nhất. Từ việc vẽ tranh đến chỉnh sửa ảnh và thiết kế đồ họa, mọi việc trở nên mượt mà và tự nhiên hơn bao giờ hết. Màn hình này không chỉ là một bảng hiển thị, mà là một công cụ sáng tạo đa năng, đem đến cho bạn sự tự do để thể hiện bản thân và tạo nên những tác phẩm độc đáo.


Detailed Specifications: 


• Hãng sản xuất: MSI
• Chủng loại: Creator Z16 HX Studio
• Part Number: B13VGTO-062VN
• Mầu sắc: Xám (Lunar Gray)– Vỏ nhôm
• Bộ vi xử lý: Intel Raptor Lake i9 13950HX – CPU thế hệ 13 mới nhất
• Chipset: Intel HM770
• Bộ nhớ trong: 64B DDR5 (32GB *2)
• Số khe cắm: 2
• Dung lượng tối đa: 64GB
• VGA: NVIDIA GeForce RTX 4070, 8GB GDDR6
• Ổ cứng: 2TB NVMe PCIe Gen5 SSD
• Ổ quang: No
• Card Reader: SD Express
• Keyboard: Per key RGB Keyboard
• Màn hình: 16 inch QHD+ (2560*1600), 120Hz, Touch
• Webcam: IR HD type (30fps@720p)
• Audio: Speakers 2W*4
• Giao tiếp không dây: Killer Wi-Fi 6E AX+BT5.3
• Cổng giao tiếp: 1x Type-C (USB / DP / Thunderbolt 4) with PD charging; 1x Type-A USB3.2 Gen2; 1x HDMI 2.1 (8K @ 60Hz / 4K @ 120Hz)
• Pin: 4 cell, 90Wh
• Kích thước (rộng x dài x cao): 359 x 256 x 18.4 mm
• Cân nặng: 2.35kg
• Hệ điều hành: Windows11 Home
• Phụ kiện đi kèm: AC 280W adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (274, 94, N'MSI Creator Z17 HX Studio', 78990000, 41, N'Description: 

Laptop MSI Creator Z17 HX Studio
MSI Creator Z17 sở hữu vẻ đẹp nghệ thuật và mang hơi hướng của sự mạnh mẽ, ngoại hình của MSI Creator Z17 cứng cáp nhờ đi kèm là một khung nhôm CNC và màu Luna Gray vô cùng tuyệt đẹp. Những tính toán và thiết kế chính xác nhất thường mang đến sự sáng tạo vượt trội, được lấy cảm hứng đến từ thời kỳ Phục Hưng, thời đại mà những công thức đều liên quan đến "tỷ lệ vàng". Creator Z17 được MSI thiết kế xen lẫn giữa hiện đại và nét cổ điển của thời kì Phục Hưng.
Với sự kết giữa hai trường phái hiện đại xen lẫn một chút cổ điển vào tác phẩm của mình, Creator Z17 sử dụng cho mình triết lý lấy con người làm trọng tâm hài hòa giữa sự tròn trịa và vuông vứt giữa các gốc cạnh của máy sử dụng những công nghệ tiên tiến nhất, đưa nền công nghệ hiện đại đến với chương mới "Công nghệ đáp ứng thẩm mỹ" vào vẻ ngoài sản phẩm của mình, mang đến những chi tiết tuyệt vời.
Chiếc laptop có kích thước 382 x 260 x 19.0 mm (Dài x Rộng x Dày) với cân nặng 2.49kg. Đây là 1 cân nặng tương đối nhẹ so với những chiếc laptop sở hữu màn hình 17.3 inch. Máy được trang bị lượng PIN lên đến 90WHrs, bạn có thể sử dụng nhiều giờ liên tục mà không cần phải cấm sạc, dễ dàng hoạt động ở hầu hết mọi nơi, như quán cà phê, thư viện, văn phòng...
Với vi xử lý CPU Intel i7-13700HX thế hệ 13 mới nhất mang lại sự mạnh mẽ, MSI Creator Z17 HX Studio A13VGT 068VN cung cấp turbo lỗi kép lên đến 5.0GHz, 16 nhân, 24 luồng, 30 MB cache mang đến sức mạnh vượt trội  nhiều so với các dòng đời cũ. Được trang bị ổ cứng SSD 2TB PCIe Gen5 cho phép bạn tắt mở máy nhanh chóng, dễ dàng lưu trữ những ứng dụng tệp dữ liệu lớn mà không lo phải hết dung lượng. Máy sử dụng RAM 32GB DDR5 5600MHz mang sức mạnh tối đa, hỗ trợ đa nhiệm làm nhiều tác vụ cùng lúc mượt mà. Máy còn hỗ trợ công nghệ Dual Channel, tối ưu hóa hiệu suất xử lý của CPU và GPU. Điều này giúp MSI Creator Z17 xử lý các tác vụ mượt mà, không gặp tình trạng giật lag hay đứng hình, đáp ứng mượt mà nhu cầu đồ hoạ, thiết kế 3D, chơi Game và làm việc đa nhiệm.
- Đối tượng mà hãng muốn nhắm đến là những người đam mê sáng tạo và làm về hình ảnh hay quay dựng video nên hãng đã trang bị cho máy tính xách tay MSI Creator Z17 HX Studio 068VN với GPU chuyên dụng Nvidia Geforce RTX 4070 8GB GDDR6 biến mọi ý tưởng, sáng tạo của bạn trở thành hiện thực, nhanh chóng và hiệu quả không bị ngắt mạnh cảm xúc khi đang sáng tạo do giật lag.
- Với việc trang bị bộ nhớ SSD M.2 PCIe Gen5 và Card đồ họa RTX 40 Series mạnh gấp nhiều lần so với các dòng khác việc chỉnh sửa hình ảnh, video dễ dàng hơn bao giờ hết. Có thể chỉnh sửa video RAW HDR lên tới 8K và xử lý các mô hình 3D cực lớn trở nên nhanh chóng hơn bao giờ hết.


Detailed Specifications: 


• Hãng sản xuất: MSI
• Chủng loại: Creator Z17 HX Studio
• Part Number: A13VGT -068VN
• Mầu sắc: Xám (Lunar Gray)– Vỏ nhôm
• Bộ vi xử lý: Intel Raptor Lake Core i7-13700HX – CPU thế hệ 13 mới nhất
• Chipset: Intel
• Bộ nhớ trong: 32B DDR5  (16GB *2)
• Số khe cắm: 2
• Dung lượng tối đa: 64GB
• VGA: NVIDIA GeForce RTX 4070 8G GDDR6
• Ổ cứng: 2TB NVMe PCIe Gen5 SSD
• Ổ quang: No
• Card Reader: SD Express
• Keyboard: Per key RGB Keyboard
• Màn hình: 17 inch QHD+ 165Hz, Touch panel (support MSI Pen Touch)
• Webcam: IR FHD type (30fps@1080p)
• Audio: Nahimic 3 / Hi-Res Audio, Speakers 2W * 2
• Giao tiếp không dây: Killer Wi-Fi 6E AX+BT5.3
• Cổng giao tiếp: 1x Type-C (USB / DP / Thunderbolt 4) with PD charging; 1x Type-C (USB / DP / Thunderbolt 4); 1x Type-A USB3.2 Gen2; 1x HDMI 2.1 (8K @ 60Hz / 4K @ 120Hz)
• Pin: 4 cell, 90Wh
• Kích thước (rộng x dài x cao): 382 x 260 x 19 mm
• Cân nặng: 2.49kg
• Hệ điều hành: Windows 11 Home
• Phụ kiện đi kèm: AC 240W adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (275, 94, N'MSI Creator M16', 38490000, 30, N'Description: 

THIẾT KẾ NHỎ GỌN ĐẦY ĐỘC ĐÁO THU HÚT
- Ngoại hình của chiếc laptop MSI Creator M16 có sự tương đồng đáng kể với mẫu Creator 15, thể hiện qua việc áp dụng một lớp sơn đen mịn phủ kín toàn bộ bề mặt máy. Những góc bo cong tinh tế được thiết kế ở bốn phía không chỉ mang đến một vẻ ngoại hình dễ chịu mà còn thể hiện sự mạnh mẽ. Chất liệu cấu tạo nên máy được làm bằng nhựa cứng tổng hợp bền bỉ, tạo cảm giác chắc chắn khi cầm nắm.
- Đặc biệt, kiến trúc thiết kế ngoại hình của MSI Creator M16 là một tượng trưng cho sự tinh tế và thanh lịch, đồng thời vô cùng phù hợp cho những ai đang làm trong lĩnh vực sáng tạo nội dung và thiết kế đồ họa. Kích thước của máy: 359 x 259 x 23.9 mm (Dài x Rộng x Dày) và khối lượng chỉ khoảng 2.25kg, một con số thực sự đáng kinh ngạc với một sản phẩm mang đầy đủ sức mạnh.
- Không chỉ dừng lại ở đó, biểu tượng rồng - biểu tượng đặc trưng của MSI - được tinh tế đặt ngay trên nắp máy, vừa để thể hiện tinh thần thương hiệu mà còn tạo điểm nhấn độc đáo không thể nhầm lẫn.
- Về khả năng vận hành, MSI Creator M16 mang trong mình viên PIN dung lượng lên tới 53WHrs, đáp ứng nhu cầu sử dụng liên tục trong thời gian dài mà không cần phải lo lắng về việc sạc pin liên tục.

HIỆU NĂNG VƯỢT TRỘI CÂN MỌI TÁC VỤ
- MSI Creator M16 B13VE 830VN tiếp tục thể hiện sự ưu việt bằng việc sử dụng một bộ xử lý CPU Intel i7-13700H (14 Cores, 20 Threads) Gen 13th. Đây là một sự kết hợp đáng kể, nâng cao khả năng xử lý đa nhiệm lý tưởng và hoàn hảo. Đồng thời mang lại trải nghiệm chuyên nghiệp không thể tốt hơn. Tần số turbo lõi kép cung cấp một hiệu suất khủng khiếp, giúp máy vượt qua các tác vụ phức tạp một cách mượt mà và nhanh chóng. Cho dù bạn đang thực hiện thiết kế đồ họa 2D hoặc 3D phức tạp, chỉnh sửa và xuất video ở chất lượng cao thì máy luôn luôn có thể làm tốt khi trang bị thêm và card đồ hoạ Nvidia GeFoce RTX 4050 6GB GDDR6 và không để bạn phải đợi lâu.
- Không chỉ tập trung vào hiệu năng xử lý, MSI Creator M16 B13VE 830VN còn đặt sự chú ý vào khả năng nâng cấp để tối ưu hóa trải nghiệm người dùng. Với bộ nhớ RAM 16GB DDR5 5200MHz và ổ cứng SSD 512GB M.2 PCle Gen4 máy mang đến hiệu suất vượt trội và ổn định, đồng thời cung cấp 2 khe cắm để bạn có thể nâng cấp bộ nhớ theo nhu cầu. Điều này đồng nghĩa với việc máy sẽ hoạt động mượt mà, trơn tru và không gặp khó khăn về việc giật lag khi sử dụng các phần mềm đòi hỏi tốn nhiều tài nguyên như trong thiết kế 3D.
- Đáng chú ý hơn, công nghệ DDR5 không chỉ mang lại hiệu suất mạnh mẽ mà còn đem đến khả năng tiết kiệm điện năng ấn tượng, tạo nên một sự kết hợp tối ưu giữa hiệu năng và hiệu quả về năng lượng, giúp bạn trải nghiệm dài lâu mà không cần phải lo lắng về thời gian sử dụng pin. Khuyến nghị dùng 2 thanh RAM tận dụng công nghệ Dual Channel mở rộng tối đa băng thông RAM đáp ứng CPU, GPU xử lý nhanh chóng và không bị tắt nghẽn hay giới hạn tốc độ của RA


Detailed Specifications: 


• Hãng sản xuất: MSI
• Chủng loại: Creator M16
• Part Number: B13VE-830VN
• Mầu sắc: Đen (core black) -  Vỏ nhôm
• Bộ vi xử lý: Intel Raptor Lake Core i7-13700H – CPU thế hệ 13 mới nhất
• Chipset: Intel
• Bộ nhớ trong: 16B DDR5 5200Mhz (8GB *2)
• Số khe cắm: 2
• Dung lượng tối đa: 64GB
• VGA: NVIDIA GeForce RTX 4050, 6GB GDDR6
• Ổ cứng: 512GB NVMe PCIe Gen4 SSD (khả năng lưu trữ tối đa : 2x M.2 SSD slot (NVMe PCIe Gen4))
• Ổ quang: No
• Keyboard: Single backlight KB(White)
• Màn hình: 16 inch FHD+ (1920*1200), IPS
• Webcam: HD type (30fps@720p)
• Audio: Speakers 2W*2
• Giao tiếp mạng: Gigabit LAN
• Giao tiếp không dây: 802.11 ax Wi-Fi 6 + Bluetooth v5.2
• Cổng giao tiếp: 
        - 1x Type-C (USB3.2 Gen1 / DP); 2x Type-A USB3.2 Gen1
        - 1x Type-A USB2.0; 1x HDMI 2.1 (8K @ 60Hz / 4K @ 120Hz); 1x RJ45
• Pin: 3 cell, 53.5Wh
• Cân nặng: 2.26kg
• Hệ điều hành: Windows 11 Home
• Phụ kiện đi kèm: AC 200W adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (276, 92, N'Dell Mobile Precision Workstation 5680 vPro Enterprise', 96999000, 67, N'

Detailed Specifications: 


• Hãng sản xuất: Dell
• Chủng loại: Workstation Mobile Precision 5680
• Part Number: 71024680
• Mầu sắc, chất liệu: Xám (Titan Gray)
• Bộ vi xử lý: Intel Core i9-13900H, vPro Enterprise (24MB Cache, 14 Cores, 20 Threads, 2.6 - 5.4 GHz Turbo, 45W)
• Bộ nhớ trong (RAM): 32 GB LPDDR5, 6000MT/s (2 x 16 GB)
• Số khe cắm RAM: 2
• Dung lượng RAM tối đa: 64 GB
• VGA: NVIDIA RTX 2000 Ada, 8GB GDDR6
• Ổ cứng: 1TB, M.2 2280, Gen 4 PCIe NVMe SSD, Class 40
• Ổ quang: No
• Card Reader: Micro SD
• Màn hình: 16 inch FHD+ non-touch, 1920 x 1200, 60Hz, 500 nits WLED, 100% DCI-P3, Low BL w/ IR Cam
• Webcam: FHD IR camera with narrow FHD+IR w/ XYZ ALS (MIPI), Dual-array microphones
• Audio: 
        - Realtek ALC711-VD
        - 2 x Woofers
        - 2 x Tweeters
• Giao tiếp không dây: Intel AX211, 2x2 MIMO, 2400 Mbps, 2.4/5/6 GHz, Wi-Fi 6/6E (WiFi 802.11ax), Bluetooth Wireless Intel AX211 WLAN Driver
• Các cổng giao tiếp: One USB 3.2 Gen 2 Type-C port with DisplayPort 1.4 Alt Mode Two Thunderbolt 4 ports (USB Type-C); One 3.5 mm audio jack; One HDMI 2.0b port
• Pin: 6 Cell, 100Wh
• Kích thước (rộng x dài x cao): 26.17 x 353.68 x 240.27 (mm)
• Cân nặng: 1.905 kg
• Hệ điều hành: Ubuntu
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (277, 95, N'LG Gram 16ZD90R-G.AX55A5', 33499000, 34, N'

Detailed Specifications: 


• Hãng sản xuất: LG
• Chủng loại: LG Gram 16ZD90R (Model 2023)
• Part Number: 16ZD90R-G.AX55A5
• Mầu sắc: Đen; Vỏ hợp kim Nano Carbon Magnesium siêu bền
• Bộ vi xử lý: i5-1340P (12 Cores 1.4Ghz up to 3.4 Ghz/12MB cache)
• Bộ nhớ trong: 16GB LPDDR5 6000MHz Dual channel Non-upgradable
• Số khe cắm: 0
• Dung lượng tối đa: 16GB
• VGA: Intel Iris Xe Graphics
• Ổ cứng: 512GB SSD NVMe Gen4 (thêm 01 khe cắm SSD M2)
• Ổ quang: None
• Bảo mật, Công nghệ: Mega cooling: Full size Backlit Keyboard
• Màn hình: 16 inch WQXGA (2560*1600) IPS LCD; chống chói; Tỷ lệ 16:10; Độ phủ màu DCI-P3 99% (Thông thường)
• Webcam: FHD IR Webcam (Nhận diện khuôn mặt Hello Windows)
• Audio: Âm thanh HD với công nghệ âm thanh vòm Dolby Atmos với Stereo Speaker
• Giao tiếp không dây: Intel Wireless-AX211 (802.11ax, 2x2, Dual Band, BT Combo)
• Cổng giao tiếp: HDMI, USB 3.2 Gen2x1 Type A (x2), USB 4 Gen3x2 Type C (x2, with Power Delivery, Display Port, Thunderbolt 4)
• Pin: 80Wh up to 23.5 giờ (Video Playback)
• Kích thước: 35.51 cm x 24.23 cm x 1.68 cm
• Cân nặng: 1199g
• Hệ điều hành: Dos
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (278, 95, N'LG Gram 14ZD90R-G.AX52A5', 22299000, 15, N'Description: 

LG gram 2023
Lưu ý: Bài viết và hình ảnh chỉ có tính chất tham khảo vì cấu hình và đặc tính sản phẩm có thể thay đổi theo thị trường và từng phiên bản. Quý khách cần cấu hình cụ thể vui lòng liên hệ với các tư vấn viên để được trợ giúp.
Ba màu máy tính xách tay LG gram được xếp theo đường chéo.
*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.


Thân máy gram mỏng và nhẹ mang đến khả năng di động và năng suất.

Siêu nhẹ nhưng siêu mạnh
Laptop mỏng nhẹ cùng với hiệu suất mạnh mẽ, LG gram mang đến cho bạn khả năng di động cao và năng suất làm việc tuyệt vời.
*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.

Thân máy gram đã qua được bài kiểm tra tiêu chuẩn quân sự MIL-STD-810H có đòi hỏi khắt khe về độ bền và độ tin cậy.
Độ bền đã được chứng minh
LG gram đã vượt qua 7 bài kiểm tra độ bền quân sự Mỹ MIL-STD-810H. Được làm từ vật liệu siêu nhẹ nhưng bền - magnesium, laptop LG gram đảm bảo độ mạnh mẽ cũng như tính di động cao.



Màn hình lớn độ phân giải cao
Bạn sẽ bị quyến rũ trước màu sắc sống động và chân thực của hình ảnh hiển thị, bởi vì laptop LG gram được thiết kế với tỷ lệ khung hình 16:10, độ phân giải WQXGA hỗ trợ gam màu rộng DCI-P3 99%, cho phép bạn xem được nhiều nội dung hơn mà không phải cuộn màn hình.



*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
**DCI-P3 Thông thường 99%, Tối thiểu 95%.
DCI-P3: Tiêu chuẩn màu được định nghĩa bởi Sáng kiến Điện ảnh Kỹ thuật số (DCI).
Dễ chịu mắt ngay cả trong ánh sáng cường độ cao
LG gram được trang bị tấm nền IPS chống lóa (Anti-Glare) cùng với độ sáng màn hình lên tới 400 nits, giúp bạn thoải mái làm việc hay thưởng thức các thước phim giải trí ngoài trời hay tại những nơi có cường độ ánh sáng cao.

*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
*Độ sáng là 350 nits (Thông thường).
Dolby Atmos Loa âm thanh vòm
Nghe, cảm nhận nhiều hơn và hòa mình trong âm nhạc hay phim ảnh thông qua loa âm thanh vòm được phát triển bởi Dobly Atmos.

*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
Nâng cấp các công nghệ mới nhất

Máy được trang bị sức mạnh của chip Intel® Core™ thế hệ thứ 13 mới nhất, đáp ứng tất cả các nhu cầu xử lý rất nặng từ chơi game đến công việc sáng tạo.

*Hình ảnh được mô phỏng để có thể hiểu tính năng rõ hơn. Hình ảnh này có thể khác với sử dụng thực tế.
Intel® Unison™ - Liên kết các thiết bị thật dễ dàng
Với phần mềm Intel® Unison™, giờ đây việc liên kết  từ các thiết bị Android hoặc iOS với gram của bạn thật dễ dàng: chuyển file, gửi tin nhắn, thực hiện cuộc gọi.


Detailed Specifications: 


• Hãng sản xuất: LG
• Chủng loại: LG Gram 14ZD90R (Model 2023)
• Part Number: 14ZD90R-G.AX52A5
• Mầu sắc: Đen; Vỏ hợp kim Nano Carbon Magnesium siêu bền
• Bộ vi xử lý: i5-1340P (12 Cores 1.4Ghz up to 3.4 Ghz/12MB cache)
• Bộ nhớ trong: 8GB LPDDR5 6000MHz Dual channel Non-upgradable
• Số khe cắm: 0
• Dung lượng tối đa: 8GB
• VGA: Intel Iris Xe Graphics
• Ổ cứng: 256GB SSD NVMe Gen4 (thêm 01 khe cắm SSD M2)
• Ổ quang: None
• Bảo mật, Công nghệ: Mega cooling: Backlit Keyboard
• Màn hình: 14.0 inch WUXGA (1920*1200) IPS LCD; chống chói; Tỷ lệ 16:10; Độ phủ màu DCI-P3 99% (Thông thường)
• Webcam: FHD IR Webcam (Nhận diện khuôn mặt Hello Windows)
• Audio: Âm thanh HD với công nghệ âm thanh vòm Dolby Atmos với Stereo Speaker
• Giao tiếp không dây: Intel Wireless-AX211 (802.11ax, 2x2, Dual Band, BT Combo)
• Cổng giao tiếp: HDMI, USB 3.2 Gen2x1 Type A (x2), USB 4 Gen3x2 Type C (x2, with Power Delivery, Display Port, Thunderbolt 4)
• Pin: 72Wh up to 24.5 giờ (Video Playback)
• Kích thước: 31.2 cm x 21.39 cm x 1.68  cm
• Cân nặng: 999g
• Hệ điều hành: Dos
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (279, 92, N'Dell Mobile Precision Workstation 7680 vPro', 85999000, 58, N'

Detailed Specifications: 


• Hãng sản xuất: Dell
• Chủng loại: Mobile Precision Workstation 7680
• Part Number: 71024676
• Mầu sắc, chất liệu: Xám (Titan Gray)
• Bộ vi xử lý: Intel Core i9-13950HX vPro (36 MB cache, 24 cores, 32 threads, up to 5.5 GHz, 55 W)
• Bộ nhớ trong (RAM): 32GB 5600MT/s SODIMM, non-ECC (2x16GB)
• Số khe cắm RAM: 2
• Dung lượng RAM tối đa: 64 GB
• VGA: NVIDIA RTX 2000 Ada 8GB GDDR6
• Ổ cứng: 1TB M.2 PCIe NVMe Gen 4 2280 SSD
• Ổ quang: No
• Card Reader: Micro SD
• Màn hình: 16 inch FHD+ 1920x1200, WVA, 60Hz, anti-glare, non-touch, 45% NTSC, 250 nits, RGB Camera, with Mic
• Webcam: FHD RGB
• Audio: Realtek ALC3281
• Giao tiếp không dây: Intel AX211 Wi-Fi 6/6E (up to 6GHz where available) 2x2 with Bluetooth Wireless Wireless Intel AX211 WLAN Driver
• Các cổng giao tiếp: 
        - One RJ45 Ethernet port
        - Two Thunderbolt 4 ports (USB Type-C)
        - One USB 3.2 Gen 2 Type-C port with DisplayPort alt mode
        - One USB 3.2 Gen 1 port with PowerShare
        - One USB 3.2 Gen 1 port
        - One HDMI 2.0a port (UMA)
        - One HDMI 2.1 port (DGPU)
• Pin: 6 Cell, 83Wh
• Kích thước (rộng x dài x cao): 22.30 x 356 x 258.34 (mm)
• Cân nặng: 2.60 kg
• Hệ điều hành: Window 11 Pro
• Phụ kiện đi kèm: AC Adapter', 0, 1)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (280, 89, N'Bàn Phím Cơ Gaming không dây Asus ROG Strix Scope II 96 Wireless NXSW/US/ABS 90MP037A-BKUA00', 3899000, 85, N'

Detailed Specifications: 


• HÃNG SẢN XUẤT: ‎ASUS
• KẾT NỐI: USB 2.0 (TypeC to TypeA)Bluetooth 5.1RF 2.4GHz
• HỆ THỐNG LED RGB: RGB TỪNG PHÍM
• USB REPORT RATE: ‎1000 Hz
• CÂN NẶNG: ‎1.17 KG
• KÍCH THƯỚC: ‎377 x 131 x 40mm
• DÂY KẾT NỐI: ‎Dây type A to type C dài 2m
• MÀU SẮC: ‎Đen
• TƯƠNG THÍCH: Windows 11', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (281, 89, N'Bàn phím Gaming ASUS ROG AZOTH/NXSW/US/PBT/WHT/Trắng _ 90MP031A-BKUA11', 6099000, 59, N'

Detailed Specifications: 


• Kết nối: USB 2.0 (TypeC sang TypeA)
• Hệ thống đèn: RGB trên mỗi phím
• AURA Sync: Có
• Bàn phím Anti-Ghosting: Chuyển đổi phím N
• Phím Macro: Tất cả các phím có thể lập trình
• Phím macro: Tất cả phím có thể lập trình
• Hệ điều hành: macOS 10.11 hoặc mới hơn
• Phần mềm: Armoury Crate
• Kích thước: 326 x 136 x 40 mm
• Trọng lượng: Keycaps PBT 1186g không có cáp
• Phụ kiện: 1 x ROG Azoth', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (282, 89, N'Bàn phím Gaming Asus ROG Azoth NX SM Black _ 90MP031B-BKUA01', 5999000, 66, N'

Detailed Specifications: 


• Nhà sản xuất: Asus
• Model: 
        - 90MP031B-BKUA01 (NX Snow Switch)
        - 90MP031A-BKUA01 (NX Storm Switch)
• Kết nối: 
        - USB 2.0 (TypeC to TypeA)
        - Bluetooth 5.1
        - RF 2.4GHz
• Chất liệu phím: ROG PBT Doubleshot
• Số phím: 81 phím
• Profile: Đang cập nhật
• Đèn nền: RGB Per keys
• Keyswitch: ROG NX Switch Snow/ Storm
• Độ bền Switch: Đang cập nhật
• Keyboard Rollover: N-key, 100% Anti-Ghosting
• Kích thước: 326 x 136 x 40 mm
• Trọng lượng: 1186g (không dây cáp)
• Khả năng tương thích: 
        - macOS 10.11 or later
        - Windows 11
• Tính năng: 
        - Bảng điều khiển và màn hình OLED trực quan
        - Macro Keys
        - Hot-Swappable
• Dạng bàn phím: 75%
• Bảo hành: 24 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (283, 89, N'Bàn phím Gaming ASUS ROG AZOTH NX RED/WL/PBT/OLED-SCR/Trắng _ 90MP0316-BKUA11', 5999000, 92, N'

Detailed Specifications: 


• Kết nối: USB 2.0 (TypeC sang TypeA)
• Hệ thống đèn: RGB trên mỗi phím
• AURA Sync: Có
• Bàn phím Anti-Ghosting: Chuyển đổi phím N
• Phím Macro: Tất cả các phím có thể lập trình
• Phím macro: Tất cả phím có thể lập trình
• Hệ điều hành: macOS 10.11 hoặc mới hơn
• Phần mềm: Armoury Crate
• Kích thước: 326 x 136 x 40 mm
• Trọng lượng: Keycaps PBT 1186g không có cáp
• Phụ kiện: 1 x ROG Azoth', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (284, 89, N'Bàn phím cơ Asus ROG Falchion Blue switch 90MP01Y2-BKUA00', 1599000, 27, N'

Detailed Specifications: 


• Thương hiệu: Asus
• Model: ROG Falchion
• Màu sắc: Đen
• Kết nối: 
        - Không dây
        - USB có dây
        - Wireless 2.4GHz
• Kiểu dáng: TKL 68 phím
• Size: 65%
• Đèn led: RBG
• Switch: Blue
• Keycaps: Doubleshot ROG PBT
• Kích thước: 305x101x38.5 mm
• Trọng lượng: 0.52 kg
• Dây cáp: USB-A to USB-C
• Thời lượng pin: ~450 giờ
• Tính năng: 
        - Phím Fn
        - Macro
        - Touch Panel', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (285, 89, N'Bàn phím Gaming Asus ROG Strix Scope II NX SM _ 90MP036B-BKUA00', 3199000, 90, N'

Detailed Specifications: 


• Nhà sản xuất: Asus
• Model: 
        - 90MP036A-BKUA00 (Snow Switch)
        - 90MP036B-BKUA00 (Storm Switch)
• Kết nối: USB 2.0 (Type-C to Type-A)
• Chất liệu phím: ABS phủ lớp chống tia UV
• Số phím: 108 phím
• Profile: Đang cập nhật
• Đèn nền: RGB Aura Sync
• Keyswitch: ROG NX Switch Snow/ Storm
• Độ bền Switch: Đang cập nhật
• Keyboard Rollover: 100% Anti-ghosting
• Kích thước: 436 x 129 x 37mm
• Trọng lượng: 839g
• Khả năng tương thích: Windows 11
• Tính năng: Macro Keys
• Dạng bàn phím: Fullsize
• Bảo hành: 24 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (286, 89, N'Bàn phím game Asus TUF K1', 849000, 37, N'Description: 

Thiết kế công thái học, thách thức thời gian
Asus TUF K1 là bàn phím chơi game mang lại hiệu năng vượt trội và độ bền thách thức thời gian. Bàn phím được trang bị các phím bấm có độ phản hồi êm ái với mỗi lần nhấn. Với phần đệm kê cổ tay có thể tháo rời và chân có thể điều chỉnh hai mức chiều cao, TUF Gaming K1 được thiết kế tiện dụng để mang lại sự thoải mái tối ưu.

Chống nước với lớp mạ chuyên dụng
TUF Gaming K1 được gia công chắc chắn cả ở phần trong và phần ngoài để có khả năng phục vụ nhiều năm liền. Lớp vỏ bên ngoài của bàn phím này có một lớp phủ gia cường đặc biệt để đáp ứng yêu cầu của hơn 10 bài thử nghiệm nghiêm ngặt về mài mòn, ma sát và mồ hôi. Với khả năng chống thấm nước lên đến 300ml, bàn phím gaming Asus này bảo đảm rằng nước tràn ra từ lon hoặc cốc sẽ không ảnh hưởng đến pha hành động của bạn.

Hiệu suất đạt chuẩn gaming
TUF Gaming K1 mang lại phản cảm giác bấm phím tuyệt vời nhờ miếng đệm giúp phím bấm bật ngược lại, không phát ra tiếng động mà vẫn rất thoải mái. Bàn phím này cũng cũng được thiết kế với công nghệ ghi nhận 19 phím bấm cùng lúc (NKRO), nhờ đó đảm bảo độ chính xác vượt trội và không bị bỏ lỡ lần nhấn phím nào.

Dải đèn RGB lấp lánh ánh sáng
TUF Gaming K1 có năm vùng chiếu sáng riêng biệt và các thanh RGB nổi bật ở cả hai bên bàn phím. Người dùng có thể lựa chọn toàn bộ phổ màu để tùy chỉnh riêng từng vùng, nhờ đó giúp bạn điều khiển dàn máy của mình tỏa sáng theo đúng ý muốn. Ứng dụng ASUS Armoury Crate với cơ chế điều khiển RGB tiên tiến giúp đồng bộ hóa cấu hình đèn và game với nội dung của bạn.

Núm vặn âm lượng chuyên dụng
Với núm chỉnh âm lượng chuyên dụng ở góc trên bên phải, TUF Gaming K1 giúp bạn điều khiển âm thanh trong game một cách nhanh chóng và dễ dàng. Bạn có thể dễ dàng vặn núm mà vẫn bám sát từng hành động trên màn hình.

Dễ dàng lập trình nhờ bộ nhớ trên bo mạch
TUF Gaming K1 có tám phím có thể lập trình, hỗ trợ ghi macro theo thời gian thực, giúp dễ dàng thiết lập bàn phím của bạn để mang lại trải nghiệm chơi cá nhân hóa. Với một bộ nhớ mặc định trên bo mạch và ba bộ nhớ tùy chỉnh, bàn phím này cho phép bạn mang theo bàn phím với các cài đặt tùy chỉnh bên mình mọi lúc mọi nơi.


Detailed Specifications: 


• Nhà sản xuất: Asus
• Tên sản phẩm: TUF K1
• Mã sản phẩm (Code/Tag): Gaming
• Kích cỡ: Fullsize
• Số lượng nút phím: 104
• Chất liệu vỏ: Nhựa
• Màu sắc vỏ: Đen nhám
• Chất liệu keycap: Nhựa
• Loại switch: Tactile TUF switch
• Màu sắc đèn LED: RGB
• Dạng kết nối: Có dây
• Loại dây: USB 2.0
• Độ dài dây: 180cm
• Trọng lượng: 810 gram
• Phụ kiện kèm hộp: HDSD
• Khác: Kê tay tháo rời', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (287, 97, N'Bàn phím AKKO 3098 DS Matcha Red Bean', 1399000, 22, N'

Detailed Specifications: 


• Thương hiệu: Akko
• Model: 3098 DS Matcha Red Bean
• Màu sắc: Green + White
• Kết nối: Có dây
• Giao tiếp: USB Type C có thể tháo rời
• Kiểu dáng: Fullsize (98 phím)
• Loại bàn phím: Bàn phím cơ
• Switch: Akko Switch v2
• Keycap: PBT Doubleshot
• Kích thước (WxDxH): 382 x 134 x 40 (mm)
• Phụ kiện: 1 sách hướng dẫn sử dụng + 1 keypuller + 1 cover che bụi + 20 keycap tặng kèm + 1 dây cáp USB', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (288, 98, N'Kit bàn phím cơ FLEsport Q75 Crystal Grey', 1249000, 68, N'Description: 

Kit bàn phím cơ FLEsport Q75 - Một kit bàn phím cơ giá khá hợp lý dành cho người dùng muốn build một chiếc bàn phím nhỏ gọn tuỳ ý theo sở thích của mình.


Ngoại hình bắt mắt

Kết cấu Gasket

Plate mềm hơn

Tối ưu âm thanh
Foam tiêu âm

Foam switch

Hỗ trợ hotswap

Bộ Stab mượt mà


Detailed Specifications: 


• THƯƠNG HIỆU: FLEsport
• Loại: Kit bàn phím cơ', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (289, 93, N'Bàn phím Lecoo KB101 đen', 129000, 22, N'Description: 

Thiết kế gọn gàng
Bàn phím Lecoo KB101 có thiết rất gọn gàng, các phím thấp giúp cho việc gõ phím êm ái và nhanh hơn



Độ bền cao
Bàn phím Lecoo KB101 được trang bị tính năng chống nước hiệu quả, có thể chống bụi bẩn tốt


Detailed Specifications: 


• THÔNG TIN CHUNG: KEYBOARD
• Nhà sản xuất: Lenovo
• Tên sản phẩm: Bàn phím văn phòng
• Mã sản phẩm (Code/Tag): Lecoo KB101
• Loại sản phẩm: Bàn phím văn phòng
• Kích cỡ: Phím: (W x D x H) : 14,00 x 44,50 x 2,30 cm
• Số lượng nút phím: 104 phím
• Chất liệu vỏ: Nhựa
• Màu sắc vỏ: Đen
• Chất liệu keycap: Nhựa
• Màu sắc đèn LED: Không
• Dạng kết nối: Nguồn USB 2.0
• Loại dây: Dây USB 2.0
• Độ dài dây: 1.5m
• Trọng lượng: 400g', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (290, 99, N'Bàn phím cơ gaming có dây Newmen GM328, Purple-White, Blue Switch', 529000, 60, N'

Detailed Specifications: 


• Phân loại sản phẩm: Bàn Phím
• Nhà sản xuất: Newmen
• Model: GM328
• Tên sản phẩm: Bàn phím cơ có dây Newmen GM328 E-Sport
• Bố cục phím: 100
• Chế độ đèn nền: hiệu ứng đèn nền cầu vồng
• Tuổi thọ trục: >70 triệu lượt nhấn
• Công nghệ: Công nghệ keycap ép phun hai màu, chống mài mòn và bền.', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (291, 100, N'Bàn phím game không dây Rapoo V500 Pro Blue sw', 649000, 36, N'Description: 

Kết nối không dây tiện lợi
V500 Pro Wireless có kết nối không dây công nghệ Wireless 2.4Ghz dễ dàng kết nối với các thiết bị PC, laptop để sử dụng, ngoài ra cũng có thể sử dụng kết nối có dây mỗi khi cắm sạc

Thiết kế bền bỉ
Phần mặt trên của bàn phím được làm bằng chất liệu kim loại chắc chắn, đồng thời cũng kèm theo tính năng chống tràn, mang lại sự an tâm khi sử dụng

Nút Media tiện lợi
Các nút Media giúp bạn có thể truy cập các tiện ích media, dừng, phát nhạc một cách tiện lợi

Switch Rapoo
Bộ Switch Rapoo với 2 phiên bản Red và Blue với độ bền rất cao lên đến 60 triệu lần nhấn, phù hợp cho cả game thủ lẫn người dùng gõ văn bản

Pin sạc
Với dung lượng  800 mAh, người dùng có thể sử dụng trong nhiều giờ liên tục, và có thể vừa cắm sạc vừa sử dụng


Detailed Specifications: 


• Thương hiệu: Rapoo
• Series/Model: Rapoo V500 Pro Wireless
• Kết nối: Có dây + Wireless 2.4GHz
• Kiểu dáng: Fullsize - 104 phím
• LED: Không
• Switch: Rapoo Blue, Red Switch
• Kích thước: Dài 43.2 cm - Rộng 13 cm - Cao 4.5 cm
• Trọng lượng: 1KG
• Phụ kiện: HDSD; Dây cáp', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (292, 101, N'Bàn phím Logitech G913 TKL Lightspeed Wireless RGB Red Linear switch', 3699000, 19, N'Description: 

Thiết kế nhỏ gọn

Công nghệ không dây cao cấp

Siêu mỏng

Switch bấm cải tiến

Led RGB

Kiểm soát không giới hạn
Đẹp mắt và tinh tế, G913 TKL đem đến trải nghiệm tập trung, hiệu suất cao với mọi tính năng bạn cần để kiểm soát hoàn toàn—như các cấu hình tích hợp và chế độ chơi game.Các tính năng nâng cao yêu cầu Phần mềm Chơi game HUB G của Logitech, có sẵn để tải về tại logitechg.com/GHUB Biến G913 TKL thành trung tâm điều khiển máy tính của bạn.



Thời lượng Pin cao

Các tính năng khác


Detailed Specifications: 


• Thương hiệu: Logitech
• Tên sản phẩm: Logitech G913 TKL
• Kích cỡ: TKL
• Số lượng nút phím: 87 phím + 9 nút chức năng
• Chất liệu vỏ: Hợp kim nhôm 5052
• Màu sắc: Xám
• Keycap: ABS
• Switch: Logitech GL Red Switch Linear
• Lực nhấn (gr): 50g
• LED: RGB 16.8 triệu màu
• Kết nối: Lightspeed / Bluetooth / Cable
• Loại dây: Dây USB
• Kích thước (mm): Dài 368 x Rộng 150 x Cao 22
• Layout: ANSI
• Antighosting (NKRO): 100%', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (293, 102, N'Bàn phím Corsair K100 RGB Optical switch', 5599000, 32, N'Description: 

Trung tâm cài đặt của bạn

Keycap PBT cao cấp
Dòng phím Cosair mới nay được nâng cấp bộ keycap với chất liệu PBT Doubleshot cực kỳ bền bỉ và cho cảm giác gõ tốt hơn rất nhiều

Bộ xử lý Corsair AXON

Switch Optical

Núm xoay iCUE Control Wheel

Macro dễ dàng


Detailed Specifications: 


• Nhà sản xuất: Corsair
• Tên sản phẩm: K100 RGB OPX
• Mã sản phẩm (Code/Tag): CH-912A01A-NA
• Loại sản phẩm: Gaming / Có dây
• Kích cỡ: Full size
• Số lượng nút phím: 110
• Chất liệu vỏ: Kim loại
• Màu sắc vỏ: Đen
• Chất liệu keycap: PBT
• Loại switch: Corsair OPX
• Lực nhấn: 45 gram
• Màu sắc đèn LED: RGB
• Dạng kết nối: USB
• Loại dây: Dây liền
• Độ dài dây: 180 cm
• Phần mềm: Corsair iCUE
• Trọng lượng: 1350 g
• Layout: ANSI
• Cổng kết nối phụ: USB x1
• Antighosting (NKRO): 100%
• Phụ kiện kèm hộp: Sách HDSD, kê tay, MOBA Keycap, FPS Keycap, Keycap Puller', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (294, 101, N'Bàn phím không dây Logitech K580 Graphite', 999000, 42, N'Description: 

Tối đa hoá không gian

Làm việc dễ dàng với EASY-SWITCH™

Kết nối theo cách bạn muốn

Yên tĩnh, thoải mái

Thời lượng pin cao

Tương thích với nhiều nền tảng


Detailed Specifications: 


• Nhà sản xuất: Logitech
• Model: 920-009210
• Kết nối: 
        - USB 2.4GHz (lên đến 10m)
        - Bluetooth
• Số phím: 102
• Màu sắc: Graphite
• Pin: 2 pin AAA
• Thời lượng pin: 24 tháng
• Dạng bàn phím: 102 Key
• Kích thước: 373.5 x 143.9 x 21.3mm
• Trọng lượng: 558g
• Tương thích hệ thống: 
        - Receiver: Windows 7,8,10 trở lên, macOS 10.10 trở lên
        - Bluetooth: Windows 7,8,10 trở lên, macOS X 10.10 trở lên, iOS 5 trở lên, iPadOS 13.4 trở lên, Android 5.0 trở lên và Surface
• Bảo hành: 12 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (295, 101, N'Bàn phím cơ Logitech G512 Lightsync RGB Linear', 1979000, 86, N'Description: 

Bàn phím cơ giá rẻ Logitech G512 GX được thiết kế hướng đến hiệu suất và tích hợp công nghệ chơi game mạnh mẽ. Từ các chi tiết tinh tế nhất như kết cấu mờ phủ vân tay và dây cáp có độ bền cao, tới chi tiết phức tạp nhất, mỗi khía cạnh được thiết kế chính xác bởi công nghệ dẫn đầu ngành của Logitech G cùng chất lượng vào kiểu dáng được chế tạo độc đáo.

Led RGB

Switch cơ cải tiến

Chất liệu chế tạo cao cấp

Cổng USB tích hợp tiện lợi

Đầy đủ chức năng

Game Mode

Khả năng nhấn cùng lúc nhiều phím

Tính năng Macro


Detailed Specifications: 


• Hãng sản xuất: Logitech
• Model: G512 GX
• Màu: Đen
• Switch: GX Brown (Tactile)/ GX Red (Linear)
• Loại kết nối: USB 2.0
• Giao thức USB: USB 2.0
• Cổng USB (Tích hợp): 2
• Led: RGB
• Kích thước: 132 x 445 x 35,5 mm
• Trọng lượng (không tính dây): 1130 g
• Độ dài dây cáp: 1,8 m
• : Điều khiển ánh sáng: FN+F5/F6/F7
• Các phím đặt biệt: 
        - Chế độ chơi game: FN+F8
        - Điều khiển phương tiện: FN+F9/F10/F11/F12
        - Điều khiển âm lượng: FN+ PRTSC/SCRLK/PAUSE
        - Các phím FN có thể lập trình qua HUB G của Logitech', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (296, 101, N'Bàn phím không dây Logitech K580 Pale Grey', 999000, 26, N'Description: 

Tối đa hoá không gian

Làm việc dễ dàng với EASY-SWITCH™

Kết nối theo cách bạn muốn

Yên tĩnh, thoải mái

Thời lượng pin cao

Tương thích với nhiều nền tảng


Detailed Specifications: 


• Nhà sản xuất: Logitech
• Model: 920-009210
• Kết nối: 
        - USB 2.4GHz (lên đến 10m)
        - Bluetooth
• Số phím: 102
• Màu sắc: Graphite
• Pin: 2 pin AAA
• Thời lượng pin: 24 tháng
• Dạng bàn phím: 102 Key
• Kích thước: 373.5 x 143.9 x 21.3mm
• Trọng lượng: 558g
• Tương thích hệ thống: 
        - Receiver: Windows 7,8,10 trở lên, macOS 10.10 trở lên
        - Bluetooth: Windows 7,8,10 trở lên, macOS X 10.10 trở lên, iOS 5 trở lên, iPadOS 13.4 trở lên, Android 5.0 trở lên và Surface
• Bảo hành: 12 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (297, 101, N'Bàn phím cơ Logitech G512 Lightsync RGB Tactile', 1979000, 76, N'Description: 

G512 là bàn phím chơi game hiệu suất cao có bao gồm lựa chọn các phím switch cơ học GX nâng cao của bạn. Công nghệ chơi game tiên tiến cùng cấu trúc hợp kim nhôm khiến cho G512 trở nên đơn giản, bền và đầy đủ tính năng.


Led RGB

Switch cơ cải tiến

Chất liệu chế tạo cao cấp

Cổng USB tích hợp tiện lợi

Đầy đủ chức năng

Game Mode

Khả năng nhấn cùng lúc nhiều phím

Tính năng Macro


Detailed Specifications: 


• Hãng sản xuất: Logitech
• Model: G512 GX
• Màu: Đen
• Switch: GX Brown (Tactile)/ GX Red (Linear)
• Loại kết nối: USB 2.0
• Giao thức USB: USB 2.0
• Cổng USB (Tích hợp): 2
• Led: RGB
• Kích thước: 132 x 445 x 35,5 mm
• Trọng lượng (không tính dây): 1130 g
• Độ dài dây cáp: 1,8 m
• : Điều khiển ánh sáng: FN+F5/F6/F7
• Các phím đặt biệt: 
        - Chế độ chơi game: FN+F8
        - Điều khiển phương tiện: FN+F9/F10/F11/F12
        - Điều khiển âm lượng: FN+ PRTSC/SCRLK/PAUSE
        - Các phím FN có thể lập trình qua HUB G của Logitech', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (298, 101, N'Bàn phím cơ Logitech G413 SE Tactile sw', 1549000, 47, N'Description: 

Switch Tactile

Keycap PBT

Led nổi bật

Anti-Ghosting

Thiết kế chắc chắn


Detailed Specifications: 


• Keycaps: PBT
• Switch: Tactile
• Kiểu bàn phím: Fullsize
• Kết nối: Có dây (USB 2.0)
• Đèn LED: Có nền trắng trên mỗi phím
• Kích thước: 435 x 127 x 36.3 (mm)
• Trọng lượng: 780g
• Tương thích: 
        - Windows  10 trở lên
        - macOS X 10.14 trở lên
• Phụ kiện: Sách HDSD', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (299, 101, N'Bàn phím cơ Logitech G413 SE TKL Tactile sw', 1549000, 44, N'Description: 

Switch Tactile

Keycap PBT

Led nổi bật

Anti-Ghosting

Thiết kế chắc chắn


Detailed Specifications: 


• Keycaps: PBT
• Switch: Tactile
• Kiểu bàn phím: TKL
• Kết nối: Có dây (USB 2.0)
• Đèn LED: Có nền trắng trên mỗi phím
• Kích thước: 355 x 127 x 36.3 (mm)
• Trọng lượng: 650g
• Tương thích: 
        - Windows 10 trở lên
        - macOS X 10.14 trở lên
• Phụ kiện: Sách HDSD', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (300, 103, N'Bàn phím cơ AULA F75 ICE Blue 3 mode', 1399000, 65, N'

Detailed Specifications: 


• THÔNG TIN CHUNG: AULA F75 BÀN PHÍM CƠ GAMING (Phiên bản Ice Blue/ Reaper switch)
• Nhà sản xuất: AULA
• Tên sản phẩm: Bàn phím cơ gaming AULA F75
• Mã sản phẩm (Code/Tag): AULA F75
• Loại sản phẩm: Bàn phím gaming
• Kích cỡ: (L x W x H): 322.7 × 143.2 × 43.1 ± 0.5 mm
• Số lượng nút phím: 80
• Chất liệu vỏ: Nhựa
• Màu sắc vỏ: Xanh nhạt-trắng-tím đậm
• Chất liệu keycap: Nhựa PBT
• Loại switch: Reaper switch
• Hiệu ứng âm thanh khi gõ phím: Linear
• Màu sắc đèn LED: LED RGB 16,8 triệu màu, 16 loại hiệu ứng
• Dạng kết nối: 3 mode có dây Type-C & không dây 2.4G & BT
• Độ bền phím: 60 Triệu lần bấm
• Loại dây: Dây USB
• Độ dài dây: 1.6m
• Phần mềm: Có phần mềm
• Điện áp định mức: DC 5V-700mA
• Trọng lượng: Khoảng 975g (không có cáp/bộ thu)/ 1023g (với cáp/bộ thu)
• Dung lượng pin: Pin lithium 4000mAh có thể sạc lại
• Antighosting (NKRO): TKL
• Phụ kiện kèm hộp: Sách hướng dẫn sử dụng + 2 Switch tặng kèm + Dây USB type-C', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (301, 103, N'Bàn phím cơ AULA F75', 1399000, 41, N'

Detailed Specifications: 


• THÔNG TIN CHUNG: AULA F75 BÀN PHÍM CƠ GAMING (Phiên bản Ice Green/ Reaper switch)
• Nhà sản xuất: AULA
• Tên sản phẩm: Bàn phím cơ gaming AULA F75
• Mã sản phẩm (Code/Tag): AULA F75
• Loại sản phẩm: Bàn phím gaming
• Kích cỡ: (L x W x H): 322.7 × 143.2 × 43.1 ± 0.5 mm
• Số lượng nút phím: 80
• Chất liệu vỏ: Nhựa
• Màu sắc vỏ: Xanh nhạt + Trắng + Xanh đậm
• Chất liệu keycap: Nhựa PBT
• Loại switch: Reaper switch
• Hiệu ứng âm thanh khi gõ phím: Linear
• Màu sắc đèn LED: LED RGB 16,8 triệu màu, 16 loại hiệu ứng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (302, 103, N'Bàn phím cơ AULA F99 3 mode', 1689000, 36, N'

Detailed Specifications: 


• THÔNG TIN CHUNG: BÀN PHÍM CƠ GAMING AULA F99 (Phiên bản xám trắng/gred wood switch)
• Nhà sản xuất: AULA
• Tên sản phẩm: BÀN PHÍM CƠ GAMING AULA F99
• Mã sản phẩm (Code/Tag): AULA F99
• Loại sản phẩm: Bàn phím gaming
• Kích cỡ: (LxWxH): 390,63 x 146,78 x 42,57 mm
• Số lượng nút phím: 99 phím
• Chất liệu vỏ: Nhựa FBT
• Màu sắc vỏ: Màu xám trắng
• Chất liệu keycap: Nhựa PBT
• Loại switch: Grey wood switch
• Hiệu ứng âm thanh khi gõ phím: Linear
• Màu sắc đèn LED: LED RGB- 16 loại hiệu ứng ánh sáng
• Dạng kết nối: 3 mode có dây Type-C & không dây 2.4G & BT
• Độ bền phím: 60 Triệu lần bấm
• Loại dây: Dây USB
• Độ dài dây: 1.6m
• Phần mềm: Có phần mềm
• Điện áp định mức: DC 5V / ≤ 250mA
• Trọng lượng: 1132g
• Dung lượng pin: Pin Li-ion có thể sạc lại 8000mAh (2*4000mAh)
• Thời gian sử dụng sau khi sạc đầy pin: Khoảng 53 giờ (hiệu ứng ánh sáng mặc định)/ 400 giờ (tất cả đèn tắt)
• Antighosting (NKRO): Full key
• Phụ kiện kèm hộp: Sách hướng dẫn sử dụng + 2 Switch tặng kèm + Dây USB type-C + Dụng cụ thay keycap', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (303, 103, N'Bàn phím cơ AULA F99', 1689000, 43, N'

Detailed Specifications: 


• Nhà sản xuất: AULA
• Tên sản phẩm: BÀN PHÍM CƠ GAMING AULA F99
• Mã sản phẩm (Code/Tag): AULA F99
• Loại sản phẩm: Bàn phím gaming
• Kích cỡ: (LxWxH): 390,63 x 146,78 x 42,57 mm
• Số lượng nút phím: 99 phím
• Chất liệu vỏ: Nhựa FBT
• Màu sắc vỏ: Màu xám trắng
• Chất liệu keycap: Nhựa PBT
• Loại switch: Agile switch
• Hiệu ứng âm thanh khi gõ phím: Linear
• Màu sắc đèn LED: LED RGB- 16 loại hiệu ứng ánh sáng
• Dạng kết nối: 3 mode có dây Type-C & không dây 2.4G & BT
• Độ bền phím: 60 Triệu lần bấm
• Loại dây: Dây USB
• Độ dài dây: 1.6m
• Phần mềm: Có phần mềm
• Điện áp định mức: DC 5V / ≤ 250mA
• Trọng lượng: 1132g
• Dung lượng pin: Pin Li-ion có thể sạc lại 8000mAh (2*4000mAh)
• Thời gian sử dụng sau khi sạc đầy pin: Khoảng 53 giờ (hiệu ứng ánh sáng mặc định)/ 400 giờ (tất cả đèn tắt)
• Antighosting (NKRO): Full key
• Phụ kiện kèm hộp: Sách hướng dẫn sử dụng + 2 Switch tặng kèm + Dây USB type-C + Dụng cụ thay keycap', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (304, 89, N'Chuột không dây Gaming ASUS ROG HARPE ACE AIM LAB Black', 2699000, 47, N'

Detailed Specifications: 


• Thương hiệu: Asus
• Model: Chuột gaming FPS không dây ROG Harpe Ace Aim Lab Edition, chuột cực nhẹ, cảm biến ROG Aimpoint độc quyền 36000 dpi, ROG SpeedNova, Aura Sync
• Màu sắc: Đen
• Kiểu dáng: Đối xứng
• Số nút: 5
• Switch chuột: Rog lên đến 70 triệu lần nhấn
• Kết nối: Có dây / Bluetooth 5.1 / Wireless 2.4GHz
• Pin: 
        - Li-Ion
        - Thời lượng pin:
        - 90 giờ (không led)
        - 79 giờ (có led)
        - Lưu ý: Thời lượng pin có thể thay đổi không như miêu tả tùy vào nhu cầu và mục đích sử dụng.
• Cảm biến: ROG AimPoint
• DPI: 36000
• IPS: 650
• Gia tốc: 50G
• AURA Sync: Có
• Phần mềm: Armoury Crate
• Kích thước: 127.5(L) x 63.7(W) x 39.6(H) mm
• Trọng lượng: 54g', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (305, 89, N'Chuột game Asus ROG Keris Wireless Aimpoint Black', 2199000, 13, N'Description: 

Asus ROG Kerris Wireless Aimpoint - Phiên bản nâng cấp với chất lượng phần cứng được cải thiện, vẫn giữ nguyên những đặc tính quen thuộc của phiên bản gốc, đem đến sự chính xác cao hơn cùng với đó là sự nhẹ nhàng thoải mái khi sử dụng.

Mắt cảm biến cao cấp

Kết nối tiện lợi

Nhẹ nhàng hơn - Bền bỉ hơn

Nút bấm chất lượng cao



Led RGB


Detailed Specifications: 


• Model: Chuột gaming FPS không dây ROG KERIS Wireless AIMPOINT màu đen, cảm biến ROG Aimpoint độc quyền 36000 DPI, switch dễ thay thế, ROG SpeedNova, Cáp Paracord
• Cảm biến: ROG AimPoint
• DPI: 36000
• Màu sắc: Đen
• IPS: 650
• Gia tốc cực đại: 50G
• AURA Sync: Có
• Pin: 370mAh
• Thời lượng pin: 
        - 119 Giờ (không led)
        - 86 Giờ (led mặc định )
        - * Thời gian sử dụng có thể thay đổi tùy thuộc vào nhu cầu và mục đích sử dụng của người dùng
• OS: 
        - Windows 10
        - Windows 11
• Kiểu game: 
        - FPS
        - MOBA
• Phần mềm: Armoury Crate
• Kích thước: 118(L)x62(w)x39(H) mm
• Trọng lượng: 75g', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (306, 89, N'Chuột Gaming không dây ASUS ROG KERIS Wireless AimPoint White 90MP02V0-BMUA10', 2699000, 90, N'

Detailed Specifications: 


• Model: Chuột gaming FPS không dây ROG KERIS Wireless AIMPOINT màu trắng, cảm biến ROG Aimpoint độc quyền 36000 DPI, switch dễ thay thế, ROG SpeedNova, Cáp Paracord
• Cảm biến: ROG AimPoint
• DPI: 36000
• Màu sắc: Trắng
• IPS: 650
• Gia tốc cực đại: 50G
• AURA Sync: Có
• Pin: 370mAh
• Thời lượng pin: 
        - 119 Giờ (không led)
        - 86 Giờ (led mặc định )
        - * Thời gian sử dụng có thể thay đổi tùy thuộc vào nhu cầu và mục đích sử dụng của người dùng
• OS: 
        - Windows 10
        - Windows 11
• Kiểu game: 
        - FPS
        - MOBA
• Phần mềm: Armoury Crate
• Kích thước: 118(L)x62(w)x39(H) mm
• Trọng lượng: 75g', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (307, 89, N'Chuột Gaming có dây ASUS TUF M3 GEN II - 90MP0320-BMUA00', 449000, 80, N'

Detailed Specifications: 


• Hãng sản xuất: Asus
• Bảo hành: 24 Tháng
• Kiểu kết nối: Có dây
• Độ nhạy (DPI): Lên đến 8000
• Cảm biến: PAW3318
• Số nút bấm: 6
• Tuổi thọ switch: Lên đến 60 triệu lần nhấn
• Kích thước: 123x68x40mm
• Khối lượng: 63g
• OS: Windows 10, Windows 11', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (308, 89, N'Chuột gaming Asus ROG Strix Impact III WL _ 90MP03D0-BMUA00', 1599000, 79, N'Description: 

CHIẾN GAME NHẸ NHÀNG, VÀO CUỘC MÃNH LIỆT
Có được khả năng kiểm soát vượt trội với ROG Strix Impact III, một chuột chơi game công thái học siêu nhẹ chỉ 59 gram, được trang bị sẵn sàng cho những pha hành động khó nhằn không ngừng nghỉ. Chuột có cảm biến 12.000 dpi với độ lệch cực thấp 1%, hoạt động click chuột tức thì và nhất quán cũng như lớp hoàn thiện có kết cấu để mang lại độ bám và độ bền cao nhất. Có ROG Strix Impact III là vũ khí phụ của bạn, bạn sẽ vượt qua được chính mình trong mọi thử thách.

THIẾT KẾ ĐỂ TRỞ THÀNH VŨ KHÍ SIÊU NHẸ, SIÊU ỔN ĐỊNH
Thiết kế rỗng bên trong của ROG Strix Impact III không chỉ tăng cường độ cứng của cấu trúc mà còn giúp giảm trọng lượng đáng kể, giúp các thao tác vuốt và di chuột nhanh trong nhiều giờ liền trở nên dễ dàng và tuyệt đối.

Hình dạng của chuột cũng được chế tạo chính xác để đảm bảo chuột phù hợp tuyệt vời với mọi kiểu cầm.

ROG Paracord cực kỳ linh hoạt và nhẹ, cộng với feet chuột 100% PTFE giảm thiểu lực cản và độ giật để di chuột nhẹ như không.

THEO DÕI CHUYỂN ĐỘNG TỪ A ĐẾN Z
Được trang bị một cảm biến quang cung cấp phạm vi 100-12000 dpi và với độ lệch 1% và chỉ số polling rate 1000 Hz dẫn đầu ngành, ROG Strix Impact III đảm bảo phản hồi nhanh và điều khiển chính xác.
Độ phân giải 100 - 12000 dpi
Tốc độ tối đa 300-ips
Gia tốc tối đa 35 g

Sử dụng nút DPI ở dưới cùng của chuột để chuyển đổi giữa bốn mức cài đặt trước hoặc sử dụng tính năng DPI-on-the-Scroll để thực hiện điều chỉnh nhanh chóng.

AURA LIGHTING
Đưa phong cách lên một tầm cao mới thông qua vô số màu sắc hoặc hiệu ứng cài sẵn với hệ thống chiếu sáng Aura Sync RGB.


Detailed Specifications: 


• Nhà sản xuất: Asus
• Model: 90MP03D0-BMUA00
• Kết nối: Bluetooth 5.1, RF 2.4GHz
• DPI: 36000 DPI
• Đèn nền: Aura Sync
• Cảm biến: ROG AimPoint
• Số nút: 5
• Switch: Switch cơ ROG
• Độ bền Switch chuột: 70 triệu lần nhấn
• Đế chuột: 100% PTFE
• Pin: Pin AA/AAA
• Thời lượng pin sử dụng: Lên đến 450 giờ (không mở đèn LED)
• Tốc độ tối đa: 650 IPS
• Tăng tốc tối đa: 50G
• Kích thước: 120 x 62 x39 mm
• Trọng lượng: 
        - 57g (không có pin và USB dongle)
        - 68g (có pin AAA và giá đỡ bộ chuyển đổi pin)
        - 72g (có pin AA)
• Bảo hành: 24 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (309, 89, N'Chuột game không dây Asus TUF M4 Wireless', 849000, 49, N'Description: 

Asus TUF M4 Wireless - Chú chuột không dây với mức giá rất hợp lý. Với cả 2 chuẩn kết nối không dây 2.4GHz / Bluetooth, TUF M4 Wireless hoàn toàn phù hợp với cả game thủ lẫn người dùng văn phòng

Tổng quan sản phẩm
Kết nối không dây hoàn toàn
TUF M4 Wireless sử dụng chuẩn kết nối không dây kép với Wireless 2.4Ghz và Bluetooh, mang lại sự ổn định và có thể sử dụng với nhiều thiết bị ở những môi trường khác nhau.

Chất liệu cao cấp
Phần mặt trên và nút hông của TUF M4 Wireless được làm từ chất liệu nhựa PBT, chống mài mòn và mang lại cảm giác bấm chắc chắn hơn. Ngoài ra, phần bề mặt cũng được kết hợp cùng công nghệ ASUS Antibacterial Guard, phương pháp xử lý ion bạc nhằm giúp ức chế sự phát triển của vi khuẩn, giúp bề mặt chuột luôn được sạch sẽ.

Sử dụng pin linh hoạt
Với việc sử dụng được cả 2 loại pin AA và AAA với adapter chuyển pin đi kèm. Người dùng có thể tuỳ chọn loại pin thích hợp cho độ nặng của chuột.

Feet PTFE
TUF M4 Wireless sử dụng feet chất liệu PTFE cao cấp, mang lại khả năng di chuột cực kỳ mượt

Tuỳ chỉnh dễ dàng
Với 6 nút có thể lập trình, TUF M4 Wireless có thể dễ dàng tuỳ biến để phù hợp với cách sử dụng của bạn, thông qua phần mềm Amoury Crate


Detailed Specifications: 


• Thương hiệu: Asus
• Bảo hành: 24 tháng
• Model: Chuột gaming không dây TUF GAMING M4 Wireless 2.4, siêu nhẹ, cảm biến 12.000 dpi, nắp vỏ bằng PBT, feet chuột 100% PTFE, Armoury Crate
• Màu sắc: Đen
• Kiểu kết nối: 
        - Wireless
        - Bluetooth 5.1
• Thời lượng pin: 
        - Pin AA
        - RF 2.4: 134 giờ
        - BLE: 232 giờ
        - Pin AAA
        - RF 2.4: 53 giờ
        - BLE: 100 giờ
• LED: Không
• Kiểu thiết kế: Công thái học
• Cảm biến: Quang học
• Độ nhạy: 12.000 DPI
• Số nút bấm: 6 nút (phần mềm Armory Crate độc quyền để cấu hình dễ dàng và trực quan dễ dùng)
• Tuổi thọ switch: 60 triệu lần click
• Kích thước: 126 x 63.5 x 39.6 mm
• Khối lượng: 
        - 77g khi dùng pin AAA & phụ kiện chuyển đổi
        - 86g khi dùng pin AA
• Phụ kiện: 
        - 1 x USB Wireless Dongle
        - 1 x AA Battery
        - 1 x AAA Battery
        - 1 x AAA to AA Battery Converter Holder
        - 1 x Hướng dẫn Nhanh
        - 1 x Warranty Card', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (310, 104, N'Chuột Edra EM624 trắng', 339000, 15, N'Description: 

Chuột gaming E-Dra EM624 LED RGB có thiết kế đơn giản nhưng rất đẹp mắt bởi giao diện đèn nền độc đáo. Độ phân giải 1200 DPI và cảm biến  6662 IC - Switch Huano 50M. Màu sắc đa dạng thích hợp cho các dàn máy tính PC chơi game. Nhìn chung, sản phẩm có mức giá phù hợp với những giá trị mà nó mang lại.
Thiết kế logo đổi mới

Dòng E-Dra EM624 đã mang đến một thiết kế hiện đại với logo cải tiến mới hơn của E-Dra. Việc thay đổi logo đầu tiên trên dòng chuột gaming này mang lại một luồng gió mới với phong cách phóng khoáng và hiện đại hơn cho sản phẩm của E-Dra.
Kiểu dáng gaming tinh gọn và hiện đại

Đèn led nền RGB chạy dọc chuột độc đáo và bắt mắt
Chuột E-DRA EM624 Gaming được thiết kế diện mạo thon gọn, dễ cầm và vững tay. Tuy vậy, chuột không quá nhỏ mà vừa vặn với lòng bàn tay, kết hợp với đèn nền RGB độc đáo và thú vị đậm chất gaming. Kích thước chuột nhỏ gọn với trọng lượng siêu nhẹ. Độ nhạy cao mang lại chất lượng và hiệu năng vượt trội hơn cho sản phẩm.
Phần cứng mạnh mẽ
Với form dáng tương tự chuột Fuhlen G90, E-Dra được trang bị thêm switch Huano siêu bền. Chip 6662 IC và độ phân giải lên đến 12000 DPI, cùng với đó là hệ thống đèn led nền RGB có thể đổi màu. Điều này mang đến mọi góc nhìn rực rỡ nhất cho sản phẩm.
Chuột E-DRA EM624 Gaming sở hữu độ nhạy cao từ công nghệ hiện đại. Nó mang đến những thao tác và phản xạ nhanh gọn và chính xác hơn. Từ đó đáp ứng hoàn toàn như cầu sử dụng của người dùng ở bất kỳ điều kiện nào. Kết hợp với chip cảm ứng quang chất lượng cao giúp tối ưu khả năng của bạn.
Độ bền cao và sự êm ái

Em chuột gaming này còn được trang bị Huano Switch có độ bền cao lên đến 50 triệu lần nhấn. Nó mang lại trải nghiệm click chuột ổn định và bền bỉ theo năm tháng. Switch cũng mang lại âm thanh khá vui tai cùng với sự êm ái của phím bấm sẽ làm bạn hoàn toàn hài lòng.
Kết nối đa dạng thuận tiện cho sử dụng
Chuột chơi game Edra EM624 được thiết kế tương thích với nhiều hệ điều hành giúp bạn tiện dụng trong kết nối với qua cổng USB thân thiện. Người dùng có thể sử dụng dễ dàng và thuận tiện hơn rất nhiều trên mọi địa hình với dây cáp dài đến 1,8m, giúp đi dây dễ dàng.


Detailed Specifications: 


• Model: EM624
• Bảo hành: 24 tháng
• DPI: 12000
• Kết nối: Có dây
• Cảm biến: 6662IC
• Switch: Huano
• Tuổi thọ switch: Lên đến 50 triệu lần nhấn
• LED: RGB', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (311, 89, N'Chuột chơi game Asus TUF M3', 399000, 46, N'Description: 

Chuột chơi game Asus TUF M3

CHIẾU SÁNG, CHIẾN TRƯỜNG KHỐC LIỆT
Asus TUF M3 là một chuột chơi game nhỏ gọn đem lại sự tiện nghi, hiệu suất và độ tin cậy mà các game thủ mong muốn. Thiết kế công thái học và trọng lượng nhẹ của nó thích hợp với phiên chơi game đường trường và cảm biến quang chính xác cao giúp bạn giành được lợi thế trên chiến trường. Công tắc có độ bền 20 triệu lần nhấn và lớp mạ chuyên dụng cho độ bền vượt trội, M3 đã được kiểm chứng đối với tác vụ khó. Nó cũng được trang bị công nghệ chiếu sáng Aura Sync RGB tùy biến để bạn có thể nổi bật về phong cách cá nhân.

THIẾT KẾ CÔNG THÁI HỌC & TRỌNG LƯỢNG NHẸ
Asus TUF M3 có kích thước nhỏ gọn và nhẹ, được tối ưu để chơi game FPS nhanh nhạy bằng kiểu cầm chuột claw hoặc fingertip grip. Thiết kế công thái học và trọng lượng nhẹ, chuột rất tiện lợi để chơi hết phiên này đến phiên khác với hình dạng tối ưu giúp tăng khả năng xử lý và điều khiển.

CẢM BIẾN QUANG DÀNH CHO CHƠI GAME
Được trang bị cảm biến quang đẳng cấp chơi game với độ phân giải từ 200 đến 7.000-dpi, tùy chỉnh dễ dàng với bốn cấp DPI thông qua ASUS Armoury II, Asus TUF M3 cho độ chính xác và tốc độ mà bạn cần để tranh tài. Và với tốc độ lấy mẫu tín hiệu 1.000Hz, bạn sẽ có được độ nhạy tối ưu để trải nghiệm chơi game siêu mượt.

CHẮC VÀ BỀN
Bên trong và bên ngoài của Asus TUF M3 được thiết kế để đảm bảo độ bền khi sử dụng trong nhiều năm. Vỏ bên ngoài của được mạ một lớp chuyên dụng để chịu được nhiều hơn 10 thử nghiệm mài mòn, ma sát và đổ mồ hôi. Và để giúp duy trì tỷ lệ K/D trong trận chiến gay cấn, các nút quan trọng sử dụng công tắc nhạy có độ bền đạt ít nhất 20 triệu lần nhấp trong khi các tính năng cơ bản được cải thiện nhờ feet Teflon để duy trì chuyển động mượt trong nhiều giờ.

CÔNG NGHỆ CHIẾU SÁNG LED AURA SYNC RGB
Aura Sync cho phép bạn thoải mái cá nhân hóa Asus TUF M3 đối với toàn bộ phổ màu và các hiệu ứng ánh sáng khác nhau. Chiếu sáng dễ dàng và được đồng bộ với hệ sinh thái Aura Sync mở rộng, vì vậy sẽ dễ dàng tạo ra một không gian chơi game có một không hai tỏa sáng thực sự.

BẢY NÚT NHẠY & LẬP TRÌNH
Asus TUF M3 trang bị bảy nút nhạy và lập trình được có chức năng cấu hình tùy chọn để cá nhân hóa chơi game. Hai công tắc DPI cho phép bạn điều chỉnh độ nhạy khi di chuyển, trong khi hai nút phía bên trái được bố trí chiến lược và một bánh lăn có thể nhấp giúp có thêm tùy chọn điều khiển.

Armoury II
Armoury II là một phần mềm dựa trên trình điều khiển cung cấp các điều khiển mở rộng và UI (giao diện người dùng) trực quan để bạn có thể dễ dàng tinh chỉnh TUF Gaming M3 để chơi game theo cách của bạn. Tạo profile, tùy biến màu sắc và hiệu ứng ánh sáng, gán nút bấm, điều chỉnh các thiết lập hiệu năng, v.v. Bạn thậm chí có thể theo dõi thống kê phần cứng trong khi chơi game để nhập phân tích dữ liệu.


Detailed Specifications: 


• Thương hiệu: Asus
• Tên sản phẩm: Asus TUF Gaming M3
• Thiết kế: Công thái học – Ergonomic
• Mắt đọc: Gaming-grade Optical Sensor
• Điểm ảnh trên 1 inch (DPI): 200 – 7000
• Inch Per Second (IPS): 100
• Gia tốc: 20g
• Tần số phản hồi: 1000Hz
• Chất liệu vỏ: Nhựa ABS
• Màu sắc: Đen
• Số lượng nút bấm: 7
• Switch: Omron
• Tuổi thọ: 20 triệu lần nhấn
• LED: RGB
• Kết nối: USB 2.0
• Loại dây: Dây USB bọc dù
• Phần mềm: Asus Armoury II
• Tương thích: Windows
• Kích thước (mm): Dài 118.2 x Rộng 68 x Cao 40
• Trọng lượng (gr): 84g (không cable)
• Khác: Sách HDSD', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (312, 102, N'Chuột chơi game không dây Corsair Harpoon RGB Wireless', 1229000, 67, N'Description: 

Kết nối không dây tiện lợi

Các tính năng tiện lợi

Trọng lượng vừa phải

Cấu hình phần cứng hợp lý


Detailed Specifications: 


• Nhà sản xuất: CORSAIR
• Tên sản phẩm: Chuột không dây Corsair Harpoon RGB
• Mã sản phẩm (Code/Tag): CH-9311011-AP
• Kiểu dáng: Công thái học
• Mắt đọc: PMW3325
• Điểm ảnh/inch (DPI/CPI): 10000
• Chất liệu vỏ: nhựa
• Màu sắc vỏ: Đen
• Màu sắc đèn LED: RGB 1 vùng
• Số lượng nút bấm: 6
• Switch nút bấm chính: 4
• Tuổi thọ switch: 50 triệu lần bấm
• Dạng kết nối: Receiver & BT
• Loại dây: Dây tháo rời
• Độ dài dây: 180 cm
• Phần mềm: Corsair iCUE
• Tương thích: Windows và MacOS
• Kích thước: 115.5 x 66.3 x 40.4 mm
• Trọng lượng: 99 gram
• Thời lượng pin: 
        - 2.4GHz SLIPSTREAM: lên đến 30 giờ với LED hay 45 giờ nếu tắt LED
        - BLUETOOTH: lên đến 40 giờ với LED hay 60 giờ nếu tắt LED
• Kiểu pin/sạc: Tích hợp lithium-polymer, có thể sạc lại
• Phụ kiện kèm theo hộp: 
        - Cáp USB
        - Đầu thu USB
• Khác: Tài liệu hướng dẫn sử dụng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (313, 102, N'Chuột không dây Corsair NIGHTSABRE RGB _ CH-931B011-AP', 3649000, 62, N'

Detailed Specifications: 


• Nhà sản xuất: Corsair
• Tên sản phẩm: Chuột không dây Corsair NIGHTSABRE RGB
• Model: CH-931B011-AP
• Kết nối: USB 2.4GHz Slipstream, Bluetooth
• : 
        - Cáp sợi bện 1.8m
        - Bluetooth: Lên đến 100h sử dụng liên tục
• DPI: 26
• Đèn nền: RGB
• Cảm biến: MARKSMAN 26K
• Số nút: 15
• Switch: Omron
• Độ bền Switch chuột: 50 triệu nhấp chuột
• Game type: MMO;MOBA;RTS
• Pin: Đang cập nhật
• Thời lượng pin sử dụng: USB 2.4GHz Slipstream: Lên đến 65h sử dụng liên tục
• Kích thước: Đang cập nhật
• Trọng lượng: 96g
• Bảo hành: 24 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (314, 101, N'Chuột không dây Logitech M185 Wireless', 229000, 13, N'Description: 

Thiết kế nhỏ gọn

Chất lượng phần cứng tốt

Thời lượng pin cao

Tương thích các nền tảng


Detailed Specifications: 


• Nhà sản xuất: Logitech
• Tên sản phẩm: M185
• Mã sản phẩm (Code/Tag): 910-002255; 910-002502; 910-002503
• Kiểu dáng: Đối xứng
• Điểm ảnh/inch (DPI/CPI): 1,000
• Chất liệu vỏ: nhựa
• Màu sắc vỏ: Xám/Xanh/Đỏ
• Số lượng nút bấm: 3
• Dạng kết nối: USB receiver 2.4 GHz
• Loại dây: không có
• Độ dài dây: không có
• Phần mềm: Logitech Options
• Tương thích: 
        - Windows 7, 8, 10 trở lên; MacOS 10.5 trở lên;
        - Chrome OS; Linux Kernel 2.6+
• Kích thước: 99x60x39
• Trọng lượng: 75.2 gram
• Thời lượng pin: lên tới 12 tháng
• Kiểu pin/sạc: 1 x AA (đi kèm)
• Phụ kiện kèm theo hộp: 
        - Chuột
        - Đầu thu USB
        - 1pin AA
• Khác: Tài liệu hướng dẫn sử dụng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (315, 101, N'Chuột game Logitech G102 Gen2 Black', 399000, 33, N'Description: 

Led RGB LightSync
Chọn từ các màu sắc sống động, cài đặt lấy cảm hứng từ trò chơi và phương tiện, hay lập trình màu sắc của riêng bạn từ 16,8 triệu màu.

Cảm biến chính xác

Thiết kế cổ điển

Ứng lực nút được tối ưu hoá


Detailed Specifications: 


• Thương hiệu: Logitech
• Tên sản phẩm: Logitech G102 Lightsync RGB Black
• Mã sản phẩm (Model): 910-005802
• Thiết kế: Đối xứng - Ambidextrous
• Mắt đọc: Mercury Sensor
• Điểm ảnh trên 1 inch (DPI): 8000
• Inch Per Second (IPS): 200
• Gia tốc: 30g
• Tần số phản hồi: 1000Hz
• Chất liệu vỏ: Nhựa ABS
• Màu sắc: Đen
• Số lượng nút bấm: 6
• Switch: Omron
• Tuổi thọ: 50 triệu lần nhấn
• LED: RGB Lightsync
• Kết nối: USB
• Loại dây: Dây USB
• Độ dài dây (cm): 210
• Phần mềm: Logitech G-Hub
• Tương thích: Windows, MacOS 10.10 trở lên
• Kích thước (mm): Dài 116.6 x Rộng 62.15 x Cao 38.2
• Trọng lượng (gr): 85g (không cable)
• Khác: Sách HDSD', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (316, 101, N'Chuột game Logitech G102 Gen2 White', 399000, 69, N'Description: 

Chuột chơi game Logitech có dây G102 Gen2 được mệnh danh là chuột logitech chơi game quốc dân vì ngoài độ nhạy cao, giá lại bình dân nên bất cứ game thủ nào cũng có thể sở hữu được

Led RGB LightSync
Chọn từ các màu sắc sống động, cài đặt lấy cảm hứng từ trò chơi và phương tiện, hay lập trình màu sắc của riêng bạn từ 16,8 triệu màu.

Cảm biến chính xác

Thiết kế cổ điển

Ứng lực nút được tối ưu hoá


Detailed Specifications: 


• Thương hiệu: Logitech
• Tên sản phẩm: Logitech G102 Lightsync RGB White
• Mã sản phẩm (Model): 910-005803
• Thiết kế: Đối xứng - Ambidextrous
• Mắt đọc: Mercury Sensor
• Điểm ảnh trên 1 inch (DPI): 8000
• Inch Per Second (IPS): 200
• Gia tốc: 30g
• Tần số phản hồi: 1000Hz
• Chất liệu vỏ: Nhựa ABS
• Màu sắc: Trắng
• Số lượng nút bấm: 6
• Switch: Omron
• Tuổi thọ: 50 triệu lần nhấn
• LED: RGB Lightsync
• Kết nối: USB
• Loại dây: Dây USB
• Độ dài dây (cm): 210
• Phần mềm: Logitech G-Hub
• Tương thích: Windows, MacOS 10.10 trở lên
• Kích thước (mm): Dài 116.6 x Rộng 62.15 x Cao 38.2
• Trọng lượng (gr): 85g (không cable)
• Khác: Sách HDSD', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (317, 101, N'Chuột game Logitech G502X trắng', 1559000, 41, N'Description: 

Cái tên G502 đã không còn xa lạ gì đối với giới game thủ. Sau thành công từ phiên bản đầu tiên, Logitech đã tung ra G502X, phiên bản cải tiến của G502 với một diện mạo hoàn toàn mới.

Trọng lượng nhẹ hơn
So với độ nặng của G502, G502X được thiết kế với khung vỏ mỏng nhẹ hơn để giảm trọng lượng xuống.

Mắt cảm biến cao cấp
Vẫn là mắt đọc Hero 25K với độ chính xác cực cao đã làm nên tên tuổi của dòng chuột LogitechG.

Switch bấm thế hệ mới
Loại Switch Hybrid mang lại cảm giác nhấn và độ bền cực cao.

Nút DPI-Shift
Nút DPI-Shift (hay trước đây còn được gọi là nút Sniper) nay được thiết kế có thể tuỳ chỉnh dễ dàng.

Nút cuộn cao cấp
Vẫn là con lăn 2 chế độ đặc trưng của dòng chuột G502, cực kỳ tiện lợi cho các tác vụ làm việc và giải trí.


Detailed Specifications: 


• Cảm biến: Hero 25K
• Kết nối: Có dây
• DPI: 100 – 25.600
• Tăng tốc tối đá: > 40G2
• Tốc độ tối đa: > 400 IPS2
• Nút: 13 Nút điều khiển có thể lập trình
• Chân PTFE: Có độ ma sát thấp
• Kích thước: 131,4 mm x 41,1 mm x 79,2 mm
• Trọng lượng: 89g
• Tương thích: 
        - Windows 10 trở lên
        - macOS 10.14 trở lên', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (318, 89, N'Chuột Gaming không dây ASUS ROG Chakram X Origin', 3299000, 40, N'

Detailed Specifications: 


• Hãng sẫn xuất: ASUS
• Tên sản phẩm: ASUS ROG CHAKRAM X ORIGIN
• Mã sản phẩm (Code/Tag): 90MP02N1-BMUA00
• Loại sản phẩm: Gaming/ Có dây/BT/Wireless
• Kiểu dáng: 
        - Kiểu cầm chuột Palm grip( thuận tay phải)
        - Kiểu cầm bằng đầu ngón tay
• Mắt đọc: ROG AimPoint
• Phụ kiện kèm theo hộp: 
        - 2 x Switch ROG Micro-Switches 3-pin (gắn sẵn trong chuột)
        - 2 x Switch micro dự phòng
        - 1 x Bộ nhận tín hiệu không dây
        - 1 x Cáp Paracord (dây dù) 2 m (Đầu đực Type-A sang đầu đực Type-C)
        - 1 x USB RF nối dài có kẹp pad (Từ Type-A cái sang Type-C cái
        - 1 x Túi bảo vệ
        - 1 x Cần điều khiển Joystick dài (để gắn vào chuột)
        - 1 x Cần điều khiển Joystick ngắn
        - 1 x Nắp che Joystick
        - 1 x Dụng cụ gỡ switch
        - 1 x Nắp đèn tự thiết kế logo
        - 1 x Tấm sticker logo ROG
        - 1 x Hướng dẫn Nhanh
        - 1 x Phiếu bảo hành', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (319, 101, N'Chuột không dây Logitech Pro X Superlight White', 2749000, 14, N'Description: 

Không có đối thủ
Là kết quả của sự hợp tác liên tục với những chuyên gia thể thao điện tử hàng đầu, PRO X SUPERLIGHT được chế tạo với một mục đích duy nhất - tạo ra con chuột chơi game không dây PRO nhẹ nhất có thể trong khi vẫn giữ được chất lượng, tính toàn vẹn về cấu trúc và các tiêu chuẩn chuyên nghiệp mà Logitech G mang lại. Về đích sớm nhất, nhanh hơn bao giờ hết.

Kết cấu siêu nhẹ

Kết nối LightSpeed siêu nhanh
Tập trung duy nhất vào việc giành chiến thắng với LIGHTSPEED, công nghệ không dây đổi mới, đẳng cấp chuyên nghiệp của chúng tôi, đem lại hiệu suất nhạy bén và khả năng kết nối mạnh mẽ.

Mắt cảm biến cao cấp

Di chuyển mượt mà

Chất liệu thân thiện với môi trường


Detailed Specifications: 


• Nhà sản xuất: Logitech
• Model: 
        - 910-005882 (Đen)
        - 910-005944 (Trắng)
        - 910-005958 (Hồng)
• Loại kết nối: không dây LIGHTSPEED
• Cảm biến: HERO
• Thời lượng Pin: 70h
• Trọng lượng: < 63G
• Độ phân giải: 100 – 25.600 DPI
• Nút thay đổi độ phân giải: Có
• Mouse Max. speed: 400 ips
• Mouse Max. acceleration: >40G
• Mouse Microprocessor: 32-bit ARM
• Pin: Có thể sạc (thông qua cáp Micro USB đi kèm)
• Thời gian phản hồi: 1000 Hz (1MS)
• Ứng dụng hỗ trợ: G HUB
• Bảo hành: 24 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (320, 101, N'Chuột không dây Logitech Pro X Superlight Black', 2749000, 75, N'Description: 

Không có đối thủ
Là kết quả của sự hợp tác liên tục với những chuyên gia thể thao điện tử hàng đầu, PRO X SUPERLIGHT được chế tạo với một mục đích duy nhất - tạo ra con chuột chơi game không dây PRO nhẹ nhất có thể trong khi vẫn giữ được chất lượng, tính toàn vẹn về cấu trúc và các tiêu chuẩn chuyên nghiệp mà Logitech G mang lại. Về đích sớm nhất, nhanh hơn bao giờ hết.

Kết cấu siêu nhẹ

Kết nối LightSpeed siêu nhanh
Tập trung duy nhất vào việc giành chiến thắng với LIGHTSPEED, công nghệ không dây đổi mới, đẳng cấp chuyên nghiệp của chúng tôi, đem lại hiệu suất nhạy bén và khả năng kết nối mạnh mẽ.

Mắt cảm biến cao cấp

Di chuyển mượt mà

Chất liệu thân thiện với môi trường


Detailed Specifications: 


• Hãng sản xuất: Logitech
• Model: G Pro X Superlight Wireless Black
• Màu: Black
• Tần suất gửi tín hiệu USB: 1000 Hz (1ms)
• Bộ vi xử lý: 32-bit ARM
• Chuyển động liên tục: 70h
• Tương thích: POWERPLAY
• Công nghệ không dây: LIGHTSPEED
• Chân: Nhựa PTFE không pha tạp
• Nút: 5 nút
• Cảm biến: HERO
• Độ phân giải: 100 – 25.400 DPI', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (321, 104, N'Chuột không dây Edra EM605W màu trắng', 199000, 34, N'

Detailed Specifications: 


• Kết nối: Không dây
• Chuẩn kết nối: Wireless 2.4G + Bluetooth
• Màu sắc: Đen/Trắng
• Mô tả khác: 
        - Switch: Huano 3M
        - Pin sạc
        - Chất liệu nhựa cao cấp
        - Thiết kế công thái học giúp gia tăng hiệu quả làm việc cho người sử dụng.
        - Tương thích hệ điều hành: Windows 98 / 2000 / ME / NT / XP / win 7/ win 8/ win 10/ win 11', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (322, 101, N'Chuột không dây Logitech M650L Signature Graphite', 629000, 45, N'Description: 

Tính năng SmartWheel

Thiết kế thoải mái

Kết nối đa dạng, tương thích nhiều nền tảng

Các tính năng khác

Giảm thiểu tiếng ồn: Công nghệ SilentTouch độc quyền của Logitech giúp giảm 90% tiếng ồn khi nhấn chuột. Tiếng ồn khi nhấn tạo ra môi trường tốt hơn, yên tĩnh hơn cho bạn và những người xung quanh
Các nút hông có thể tuỳ chỉnh: Dễ dàng tùy chỉnh các nút bên với Logitech Options+, khả dụng trên Windows và macOS, thành các chức năng ưa thích của bạn – như quay lại/tiếp theo hoặc sao chép/dán.
Thời lượng pin cao: Chuột Signature M650 đi kèm với một quả pin AA có thời gian sử dụng lên tới 2 năm (Tuỳ vào điều kiện và mức độ sử dụng.


Detailed Specifications: 


• Nhà sản xuất: Logitech
• Model: 
        - 910-006249 (Off-White)
        - 910-006247 (Graphite)
• Loại kết nối: không dây usb 2.4GHz và Bluetooth
• Cảm biến: Cảm biến Quang học
• Khoảng cách kết nối: 10m
• Độ phân giải: 400 - 4000 DPI
• Pin: 1 pin AA
• Hỗ trợ công nghệ: Silent Touch
• Màu sắc: Off-White, Graphite
• Thời lượng pin: 
        - USB Logi Bolt: Lên đến 24 tháng
        - Bluetooth: Lên đến 20 tháng
• Số nút: 5 nút
• Tương thích hệ thống: MacOS 10.14 trở lên và Windows 10, 11 trở lên
• Kích thước: 118.19 x 65.63 x 41.52mm
• Trọng lượng: 111.2g
• Bảo hành: 12 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (323, 104, N'Chuột không dây Edra EM605W màu đen', 199000, 93, N'

Detailed Specifications: 


• Kết nối: Không dây
• Chuẩn kết nối: Wireless 2.4G + Bluetooth
• Màu sắc: Đen/Trắng
• Mô tả khác: 
        - Switch: Huano 3M
        - Pin sạc
        - Chất liệu nhựa cao cấp
        - Thiết kế công thái học giúp gia tăng hiệu quả làm việc cho người sử dụng.
        - Tương thích hệ điều hành: Windows 98 / 2000 / ME / NT / XP / win 7/ win 8/ win 10/ win 11', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (324, 99, N'Chuột Newmen M007', 79000, 45, N'Description: 

Thiết kế
Newmen M007 có thiết kế đối xứng dễ cầm nắm. Phần vỏ được làm từ nhựa ABS siêu bền được phủ nhám giúp cầm nắm dễ dàng hơn

Hiệu năng
Với độ phân giải 1200 DPI, Newmen M007 dễ dàng đáp ứng được các yêu cầu công việc cần tốc độ cao. Nút bấm sử dụng switch Kailh mang lại độ bền lên đến 5 triệu lần nhấn


Detailed Specifications: 


• Nhà sản xuất: NEWMEN
• Tên sản phẩm: Chuột Newmen M007
• Mã sản phẩm (Code/Tag): M007
• Kiểu dáng: Thiết kế đối xứng dễ cầm nắm
• Điểm ảnh/inch (DPI/CPI): 1200DPI
• Chất liệu vỏ: Nhựa ABS. Bề mặt nhám, chống xước, chống bụi
• Màu sắc vỏ: Đen
• Switch nút bấm chính: Kailh
• Tuổi thọ switch: 5 triệu lượt nhấn
• Dạng kết nối: USB
• Loại dây: dây nhựa
• Độ dài dây: 1.8m
• Phụ kiện kèm theo hộp: Thẻ, hướng dẫn sử dụng
• Bảo hành: 24 tháng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (325, 100, N'Tai nghe Gaming Rapoo VH310', 389000, 91, N'Description: 

Âm thanh sống động
Rapoo VH310 trang bị công nghệ giả lập âm thanh vòm 7.1, mang lại âm thanh sống động, và khả năng tái tạo âm thanh các hướng tốt nhằm phát hiện đối thủ tốt hơn

Màng loa 50mm
Với màng loa 50mm, âm thanh được tái hiện chân thực hơn,âm thanh nghe to, rõ ràng và chính xác hơn rất nhiều

Micro chất lượng tốt
Micro 360 độ với tính năng lọc ồn mang lại chất lượng cuộc trò chuyện tốt nhất, dễ dàng giao tiếp với bạn bè trong game

Led RGB
Không thể thiếu với một sản phẩm dành cho Gaming, Rapoo VH310 cũng được tích hợp led RGB với các hiệu ứng khác nhau nổi bật

Thiết kế thoải mái
Rapoo VH310 được thiết kế với phần khung kim loại chắc chắn, headband co giãn giúp giảm thiểu áp lực khiến người dùng đeo thoải mái hơn.


Detailed Specifications: 


• Sản phẩm: Tai nghe
• Hãng sản xuất: Rapoo
• Model: VH310 7.1 Gaming
• Thiết kế: Chụp tai
• Kết nối: USB
• Microphone: Có
• Màu sắc: Black
• Mô tả khác: 
        - Hiệu ứng âm thanh Virtual 7.1 mang đến cho bạn trải nghiệm âm thanh vòm chân thực trong game.
        - Thiết kế khung choàng độc đáo với hệ thống treo nhẹ mang cảm giác thoải mái.
        - Âm thanh chuyên nghiệp rõ ràng
        - Thiết kế cách âm với cúp tai mềm thoải mái
        - Chất liệu chế tạo cứng cáp và bền bỉ
        - Chức năng điều khiển đa chức năng trên dây
        - Microphone khử ồn ENC cho cuộc hội thoại HD, rõ ràng ổn định.
        - Có LED nhịp thở định vị bắt mắt.', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (326, 89, N'Tai nghe chơi game Asus ROG Cetra II Core', 899000, 24, N'Description: 

Driver ASUS Essence
Được làm bằng vật liệu Liquid Silicone Rubber (LSR) tiên tiến, các trình điều khiển ASUS Essence trên ROG Cetra II Core cung cấp hiệu suất loa ổn định hơn và âm trầm cực mạnh. Với âm thanh được tối ưu hóa để chơi game, bạn sẽ được thưởng thức âm thanh vô cùng sống động và chi tiết khi chơi các trò chơi yêu thích của mình.

Lý tưởng cho chơi game cầm tay
ROG Cetra II Core được thiết kế với đầu nối 90 ° giúp giữ cho cáp tai nghe không bị vướng, cải thiện sự thoải mái khi chơi game di động.

Thiết kế cho sự thoải mái

Độ Fit tai hoàn hảo
Vây tai và Tips đi kèm được làm bằng cao su silicone lỏng và có kết cấu siêu mềm để tạo sự thoải mái hơn trong các phiên chơi game kéo dài. Thiết kế miếng đệm tai nghe hơi nghiêng về phía trước để tạo sự vừa vặn và mỗi miếng đệm tai nghe đều có một mấu nhỏ ở đế để cố định nó trong tai. Những thiết kế công thái học này trên ROG Cetra II Core giúp tăng cường khả năng cách ly tiếng ồn, mang lại sự thoải mái và phù hợp tối đa để có trải nghiệm nghe tốt nhất khi chơi game.
Nhẹ nhàng, bền bỉ
Được chế tác từ nhôm nhẹ, kiểu dáng đẹp, ROG Cetra II Core có vẻ ngoài thanh lịch, nổi bật cùng với khả năng chống xước, nâng cao tính thẩm mỹ và độ bền.
Điều khiển nhanh bằng tay
Được bọc trong một lớp hoàn thiện bằng kim loại tinh tế, các nút điều khiển tích hợp trên dây giúp tuỳ chỉnh ngay tức thì, thuận tiện để phát, tạm dừng và nút âm lượng.

Tương thích nhiều nền tảng
ROG Cetra II Core có đầu nối 3,5 mm hỗ trợ nhiều loại thiết bị - bao gồm khả năng tương thích với ROG Phone 5, Nintendo Switch ™, PlayStation® 5, Xbox One ™, Xbox Series X / S, điện thoại di động, PC và Mac - cho phép Game thủ để tận hưởng trải nghiệm âm thanh sống động trên nền tảng mà họ lựa chọn.

Hộp đựng tiện lợi
ROG Cetra II Core đi kèm với một hộp đựng du lịch nhỏ gọn để dễ dàng cất giữ khi di chuyển. Ba cặp tips tai nghe LSR và vây tai, cùng với một cặp tip bằng xốp  - vì vậy bạn chắc chắn sẽ có được một chiếc tai vừa vặn thoải mái và an toàn.


Detailed Specifications: 


• Thương hiệu: Asus
• Model: ROG Cetra II Core
• Kết nối: Jack 3.5mm
• Chiều dài cap: 1,25 m
• Kích thước driver: 9.4mm
• Trở kháng: 32ohm
• Phản hồi tần số: 20Hz - 40KHz
• Trọng lượng: 18g
• Phụ kiện: 
        - Bao đựng tai nghe, 03 đôi Ear fin, 03 đôi Ear tip
        - Mic splitter cable', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (327, 89, N'Tai nghe Asus ROG Cetra True Wireless 90YH03G1-B5UA00', 1899000, 87, N'Description: 

Gaming Mode
Kích hoạt tính năng này giúp cho việc chơi game thoải mái hơn với âm thanh độ trễ cực thấp

Tính năng chống ồn cao cấp
Tính năng chống ồn kép mang lại trải nghiệm chơi game tập trung nhất, không bị quấy rầy bởi tiếng ồn

Âm thanh sống động
Trải nghiệm âm thanh sống động với driver cao cấp đến từ Asus ROG

Thời lượng sử dụng lâu
Asus ROG Cetra True Wireless mang lại thời lượng sử dụng khá cao, cùng với đó là tính năng sạc nhanh, kết hợp với tính năng sạc không dây, giúp bạn có thể sử dụng thoải mái cả ngày


Tính năng chống nước
Thoải mái sử dụng với các hoạt động ngoài trời với tính năng chống nước chuẩn IPX4

Sử dụng dễ dàng
Thao tác dễ dàng với chạm cảm ứng đơn giản cho các tác vụ cần thiết


Detailed Specifications: 


• Nhà sản xuất: ASUS
• Tên sản phẩm: ROG Cetra True WL
• Loại tai nghe: True Wireless
• Chất liệu: Nhựa
• Màu sắc: Đen
• LED: RGB
• Kết nối: Bluetooth 5.0
• Âm thanh vòm: Hỗ trợ bộ chỉnh âm Eq/âm thanh ảo 7.1
• Pin tai nghe + hộp sạc: 
        - 4mAh
        - 4.8 + 17 giờ (Bật ANC)
        - 5.5 + 21.5 giờ (Tắt ANC)
• Hộp sạc: Sạc không dây/ Sạc qua dây cable Type-C
• Chất liệu trình điều khiển: nam châm Neodymium
• Kích thước Trình điều khiển(mm): 10mm
• Tần số đáp ứng tai nghe (Hz): 20Hz - 20KHz
• Trở kháng: 32Ω
• Khoảng cách kết nối: Support SBC & AAC Audio Codec
• Tương thích: 
        - PC
        - MAC
        - Máy chơi game Nintendo Switch
        - iOS
        - Android
        - Bluetooth device
• Phần mềm: Armory Crate/Armory Crate Mobile
• Chuẩn chống nước: IPX4
• Trọng lượng: 
        - Tai nghe (mỗi bên) nặng 5g
        - Hộp đựng nặng 42g
• Ghi chú: Điều khiển cảm ứng
• Loại microphone: Đa hướng (Omnidirectional)
• Độ nhạy: 38 dB
• Tần số đáp ứng: 100Hz -10kHz
• Khử tiếng ồn: Công nghệ chống ồn chủ động (ANC)
• Phụ kiện kèm theo hộp: 
        - 2 đôi nút tai
        - Cáp sạc(60 cm)
        - Hướng dẫn nhanh', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (328, 89, N'Tai nghe chơi game Asus TUF GAMING H3 Red Đen Đỏ', 849000, 94, N'Description: 

Thiết kế nhẹ,bền
Tai nghe TUF Gaming H3 mới được thiết kế để mang lại sự thoải mái và độ bền vượt trội dành cho các game thủ chơi hoặc phát phiên game đường trường. Với kết cấu có trọng lượng nhẹ, đệm tai nghe bằng mút mềm, vòng đeo bằng thép không gỉ, màng loa ASUS Essence 50 mm và thiết kế công nghệ buồng cách âm, tai nghe TUF Gaming H3 nâng cao trải nghiệm âm thanh trong game của bạn bằng âm thanh phong phú, đắm chìm.
Âm trầm cực sâu & chi tiết
Trang bị công nghệ buồng cách âm độc quyền và màng loa ASUS Essence  Tai nghe Gaming Asus TUF H3 kế thừa các tính năng chuẩn mực nhất của các bộ tai nghe chơi game ASUS: công nghệ buồng cách âm độc quyền và màng loa ASUS Essence cho âm thanh sắc nét hơn với âm trầm mạnh để bạn được đắm chìm trong trải nghiệm chơi game với âm thanh tự nhiên.
Âm thanh vòm ảo 7.1  Công nghệ âm thanh vòm ảo 7.1* nâng cao độ chính xác âm thanh để giúp bạn giành lợi thế tuyệt đối.
* Được hỗ trợ bởi Windows Sonic.

Thiết kế với trọng lượng nhẹ đảm bảo sự thoải mái  Với trọng lượng chỉ 294 gam, kết cấu có trọng lượng nhẹ của tai nghe TUF Gaming H3 được thiết kế để giúp bạn thoải mái trong các phiên game đường trường.
Đệm tai nghe bằng mút mềm  Tai nghe TUF Gaming H3 trang bị đệm tai nghe với lớp bọc bằng da protein 100% và đệm bọt mềm để đem lại mức độ thoải mái tối ưu.
Độ bền bỉ cao
Vòng đeo bằng thép không gỉ  Chịu được các điều kiện khắc nghiệt của chơi game cường độ cao, vòng đeo trên tai nghe TUF Gaming H3 được làm bằng thép không gỉ. Để tăng cường mức độ thoải mái, vòng đeo được thiết kế để tạo ra một lực kẹp ít hơn 20% so với các vòng đeo khác.
Giao tiếp cực kỳ rõ ràng  Tai nghe TUF Gaming H3 gồm một micro gắn một chiều được tinh chỉnh đặc biệt để giao tiếp rõ bằng giọng nói và được kiểm chứng bằng các ứng dụng giao tiếp hàng đầu. Các nút điều khiển trực quan trên ốp tai nghe cho phép bạn điều chỉnh âm lượng tức thì hoặc tắt micro.


Detailed Specifications: 


• Sản phẩm: Tai nghe
• Hãng sản xuất: Asus
• Model: TUF GAMING H3
• Thiết kế: Chụp tai
• Kết nối: Jắc 3.5mm
• Microphone: Có
• Màu sắc: Black Red
• Mô tả khác: Microphone: Uni-directional. Headphones Impedance: 32 Ohm. Frequency Response (headphones): 20 ~ 20000 Hz. Frequency Response Microphone boom: 50 ~ 10000 Hz. Sensitivity Microphone boom: Sensitivity : -40 dB.', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (329, 89, N'Tai nghe Asus ROG Cetra True Wireless White 90YH03X1-B5UA00', 1899000, 11, N'Description: 

Tai nghe gaming ROG Cetra True Wireless được trang bị công nghệ Chống ồn Hybrid ANC và kết nối không dây có độ trễ thấp, giúp bạn luôn giữ kết nối với mọi người và đồng bộ với trải nghiệm âm thanh sống động.

Gaming Mode
Kích hoạt tính năng này giúp cho việc chơi game thoải mái hơn với âm thanh độ trễ cực thấp

Tính năng chống ồn cao cấp
Tính năng chống ồn kép mang lại trải nghiệm chơi game tập trung nhất, không bị quấy rầy bởi tiếng ồn

Âm thanh sống động
Trải nghiệm âm thanh sống động với driver cao cấp đến từ Asus ROG

Thời lượng sử dụng lâu
Asus ROG Cetra True Wireless mang lại thời lượng sử dụng khá cao, cùng với đó là tính năng sạc nhanh, kết hợp với tính năng sạc không dây, giúp bạn có thể sử dụng thoải mái cả ngày


Tính năng chống nước
Thoải mái sử dụng với các hoạt động ngoài trời với tính năng chống nước chuẩn IPX4

Sử dụng dễ dàng
Thao tác dễ dàng với chạm cảm ứng đơn giản cho các tác vụ cần thiết


Detailed Specifications: 


• Nhà sản xuất: ASUS
• Tên sản phẩm: ROG Cetra True WL
• Loại tai nghe: True Wireless
• Chất liệu: Nhựa
• Màu sắc: Trắng
• LED: RGB
• Kết nối: Bluetooth 5.0
• Âm thanh vòm: Hỗ trợ bộ chỉnh âm Eq/âm thanh ảo 7.1
• Pin tai nghe + hộp sạc: 
        - 4mAh
        - 4.8 + 17 giờ (Bật ANC)
        - 5.5 + 21.5 giờ (Tắt ANC)
• Hộp sạc: Sạc không dây/ Sạc qua dây cable Type-C
• Chất liệu trình điều khiển: nam châm Neodymium
• Kích thước Trình điều khiển(mm): 10mm', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (330, 89, N'Tai nghe ASUS TUF Gaming H1', 749000, 65, N'Description: 

Chất âm chi tiết - Bass sâu
Tai nghe Asus TUF Gaming H1 được thiết kế với những công nghệ độc quyền từ Asus, bao gồm Driver Asus Essence 40mm, công nghệ buồng âm kín mang lại chất lượng âm thanh cực chi tiết và âm bass sâu

Giả lập âm thanh vòm 7.1
Công nghệ âm thanh vòm ảo 7.1 * cung cấp mức độ chính xác âm thanh rõ ràng, có thể mang lại cho bạn lợi thế trong khi chơi trò chơi.
* Được hỗ trợ bởi Windows Sonic

Micro chất lượng cao
Micro 1 chiều với chất lượng truyền tải giọng nói rõ ràng, được chứng nhận bởi Discord và TeamSpeak

Thiết kế thoải mái
Chỉ nặng 287 gram, tai nghe TUF Gaming H1 nhẹ được thiết kế để giúp bạn thoải mái trong các phiên chơi game kéo dài.


Điều khiển dễ dàng
Các nút điều khiển tiện dụng và trực quan trên củ tai giúp bạn dễ dàng điều chỉnh âm lượng, tắt tiếng hoặc bật tiếng micrô.


Tương thích đa nền tảng
Với TUF Gaming H1, bạn không cần một tai nghe khác để chơi game console - vì nó cung cấp hỗ trợ đa nền tảng thực sự toàn diện, bao gồm cả PC, Mac, PlayStation® 4 & 5, Nintendo Switch ™, XBOX ™ One & Series X | S, điện thoại thông minh và máy tính bảng.


Detailed Specifications: 


• Trọng lượng: 287g
• ASUS Essence drivers: (40mm)
• Công nghệ âm thanh: Giả lập âm thanh vòm 7.1
• Chất liệu: Nhựa, da
• Micro: Có
• Tương thích: PCs, Macs, tablets, smartphones, PlayStation 4 & 5, Nintendo Switch and XBOX One & Series X | S
• Màu: Đen', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (331, 105, N'Tai nghe Asus ROG Delta S EVA 90YH03H0-B2UA00', 4799000, 14, N'Description: 

Tai nghe Asus ROG Delta S Eva Edition - Phiên bản đặc biệt lấy cảm hứng từ dự án Gundam EVANGELION với tông màu xanh tím cực đẹp, 1 sản phẩm cưc kỳ đáng để sở hữu, đặc biệt là đối với các fan của Gundam

Chip xử lý âm thanh cao cấp
Bộ giải mã Quad DAC™ ESS 9281 chứa bốn bộ chuyển đổi kỹ thuật số digital-to-analog (DAC) cung cấp khả năng xử lý âm thanh lossless. Có một DAC cho từng dải tần — thấp, trung, cao và siêu cao — mang đến âm thanh rõ ràng hơn và chỉ số SNR 130 dB cao ngất ngưỡng. Với tai nghe gaming ROG Delta S phiên bản EVA, bạn có thể nghe rõ từng chi tiết và tận hưởng âm thanh sắc nét, sống động như thật.

Driver cao cấp
Các driver ASUS Essence độc quyền trong ROG Delta S đã được trang bị công nghệ Chuyển đổi tín hiệu âm thanh để có âm thanh rõ ràng hơn. Bên cạnh đó, các driver độ phân giải cao này có đáp ứng tần số rộng 20–40 kHz để cung cấp âm trầm cực mạnh và tối ưu hóa âm thanh trong game, vì vậy bạn sẽ nghe thấy mọi chi tiết trong khi tận hưởng trải nghiệm âm thanh đắm chìm không gian một cách toàn diện.

Công nghệ độc quyền cho âm thanh chi tiết
Công nghệ ROG Hyper-Grounding độc quyền tận dụng bảng mạch in nhiều lớp và bố cục đặc biệt để chống nhiễu điện từ, đảm bảo rằng tất cả những gì bạn nghe là âm thanh tinh khiết nhất, không lẫn tạp âm.

Micro AI cao cấp
Micrô Khử ồn thông minh AI Noise-Canceling của ASUS (Micrô AI) có một bộ xử lý chuyên dụng được thiết kế để giảm hơn 500 triệu loại tiếng ồn xung quanh đồng thời duy trì các sóng hài giọng nói để giao tiếp voicecall trong game rõ ràng, giọng nói trong hơn. Các tiếng ồn xung quanh thông thường như tiếng nói chuyện, tiếng bàn phím và tiếng click chuột được giảm đến 95%.

Led RGB
Hệ thống đèn Aura RGB có thể tùy chỉnh cung cấp hơn 16,8 triệu màu để kết hợp cùng với các hiệu ứng ánh sáng cài đặt sẵn. Thêm vào đó, hiệu ứng ánh sáng đèn Soundwave độc quyền làm cho đèn nhấp nháy đồng bộ với âm thanh giọng nói của bạn.

Thiết kế thoải mái
So với chụp tai hình oval, chụp tai thiết kế dạng chữ D công thái học của ROG Delta S gần giống với hình dạng của đôi tai bạn, giảm diện tích tiếp xúc không cần thiết lên đến 20%. Các driver trong mỗi phần ốp tai được nghiêng 12 độ, gần giống với góc tự nhiên của tai người. Thiết kế có độ nghiêng mang lại sự thoải mái hơn và cũng giúp cải thiện chất lượng âm thanh bằng cách cho phép tín hiệu âm thanh truyền trực tiếp vào ống tai.
Đệm được làm bằng da protein kết hợp memory foam làm mát nhanh, để mang lại sự thoải mái vô song với chất liệu mỏng hơn và mềm hơn.

ROG Delta S cung cấp hai loại đệm tai để bạn lựa chọn, dựa trên sở thích của bạn.

Điều khiển dễ dàng
Các nút điều khiển trực quan trên tai nghe cho phép bạn điều chỉnh ngay âm lượng, tắt tiếng micrô hoặc điều chỉnh đèn RGB trong khi chơi game.


Detailed Specifications: 


• Hãng sản xuất: ASUS ROG
• Model: Delta S Eva Edition
• Màu sắc: Special edition
• LED: RGB
• Kích thước màng loa: 50mm
• Tần số đáp ứng: 20 ~ 40000 Hz
• Trở kháng: 32 Ohm
• Cổng kết nối: 
        - USB-A
        - USB-C
• Độ phản hồi microphone: 100 ~ 10000 Hz
• Độ nhạy microphone: 40 dB
• Chiều dài dây: Cáp USB-C: 1,5m; Cáp USB 2.0: 1m', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (332, 106, N'Tai Nghe Dareu EH925 RGB Black', 849000, 61, N'

Detailed Specifications: 


• Sản phẩm: Tai nghe
• Hãng sản xuất: Dareu
• Model: EH925 RGB
• Thiết kế: Chụp tai
• Kết nối: USB
• Microphone: Có
• Màu sắc: Đen
• Mô tả khác: Tai nghe Over Ear - RGB. Hiệu ứng: giả lặp 7.1. Đệm tai: da mềm. Headband: kim loại. Frequency Range: 20Hz-20KHz. Mic liền.', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (333, 102, N'Tai nghe không dây Corsair Virtuoso XT CA-9011188-AP', 6199000, 92, N'Description: 

Nhiều dạng kết nối
Corsair Virtuoso XT là chiếc tai nghe cao cấp với tính năng nổi bật là có thể kết nối với nhiều các khác nhau:
SlipStream Wireless: Công nghệ kết nối không dây Wireless với độ trễ cực thấp với khoảng cách hoạt động lên đến 20m
Dây USB: Âm thanh có độ trung thực cao, 24bit / 96kHz cho trải nghiệm nghe đỉnh cao với các bản ghi âm tương thích.
Jack 3.5mm: Kết nối đa năng để nghe trên nhiều loại thiết bị như DAC, máy nghe nhạc và thiết bị di động.
Bluetooth: Kết nối với bất kỳ thiết bị Bluetooth® Qualcomm® aptX ™ HD nào với độ trễ thấp để có âm thanh độ phân giải cao được đồng bộ hóa

Công nghệ âm thanh Dolby Atmos
Công nghệ âm thanh Dolby Atmos giúp cho âm thanh trong trò chơi của bạn trở nên chính xác hơn, giúp bạn có thể phản ứng nhanh hơn trong nhiều tình huống

Chất lượng âm thanh cao cấp
Driver Neodymium 50mm được thiết kế điều chỉnh tối ưu mang đến chất lượng âm thanh cực cao với dải tần từ 20Hz-40.000Hz - gấp đôi so với các tai nghe chơi game thông thường.

Microphone cao cấp
Micro đa hướng có thể tháo rời, băng thông cao, khiến cho chất lượng giọng nói rõ ràng, chất lượng phản hồi tuyệt vời

Các tính năng khác

Kết nối không dây đơn giản: Kết hợp SLIPSTREAM WIRELESS cho âm thanh trò chơi có độ trung thực cao với Bluetooth® cho các ứng dụng trò chuyện thoại, âm nhạc, cuộc gọi điện thoại và hơn thế nữa.
Tương thích đa nền tảng với kết nối có dây: Kết nối với hầu hết mọi thiết bị bao gồm PC, PS4, Nintendo Switch và thiết bị di động có dây 3.5mm.
Led RGB: Nhôm đục lỗ siêu nhỏ trên mỗi củ tai cho phép hệ thống đèn RGB chiếu qua cho các tùy chọn màu sắc và tùy chỉnh hầu như không giới hạn để phù hợp với mọi phong cách.
Điều khiển tích hợp: Cung cấp khả năng truy cập thuận tiện vào các điều khiển âm lượng và tắt tiếng.
Túi đựng đi kèm: Đựng chiếc tai nghe của bạn với túi đựng đi kèm, tiện lợi khi mang đi bất cứ đâu


Detailed Specifications: 


• Hãng sản xuất: Corsair
• Model: Virtuoso RGB Wireless XT
• Tần số tai nghe: 20Hz - 40 kHz
• Tuổi thọ pin tai nghe: Lên đến 15 giờ
• Độ nhạy tai nghe: 109dB (+/- 3dB)
• Phạm vi không dây của tai nghe: Lên đến 60ft
• Trở kháng: 32 Ohms @ 2,5 kHz
• Loại đầu nối tai nghe: Bộ thu không dây USB
• Trình điều khiển tai nghe: 50mm
• Âm thanh: Dolby Atmos
• Đèn LED: RGB
• Trở kháng micrô: 2,2k Ohms
• Loại micrô: Đa hướng
• Đáp ứng tần số micrô: 100Hz đến 10kHz
• Độ nhạy của micrô: 42dB (+/- 2dB)', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (334, 105, N'Tai nghe gaming Asus ROG CETRA TRUE WIRELESS SPEED NOVA', 5099000, 44, N'

Detailed Specifications: 


• Thương hiệu: Asus ROG
• Tên sản phẩm: Asus ROG CETRA TRUE WIRELESS SPEED NOVA
• Loại tai nghe: True Wireless (In-ear)
• Màng loa: Nam châm neodymium 10 mm
• Chất liệu: Nhựa
• Màu sắc: Black
• LED: RGB
• Kết nối: 
        - Bluetooth 5.3
        - 2.4 GHz (USB-C / USB-A*)
• Tương thích: 
        - Chế độ Bluetooth: PC, Mac, iOS, Android, Nintendo Switch.
        - Chế độ bộ thu SpeedNova: PC, Mac, Android, Nintendo Switch, PlayStation 4, PlayStation 5
• Loại microphone: 
        - Micrô tạo tia khử tiếng ồn và
        - dẫn truyền qua xương bằng AI
• Chống nước: IPX4
• Công nghệ ANC: 
        - ANC thích ứng
        - (Tự động/ANC Thấp/ANC Trung bình/ANC Cao),
• Pin: 
        - 7,5 + 22,5 giờ (bật ANC, tắt RGB)
        - 6,5 +19,5 giờ (bật ANC, bật RGB)
        - 11,5 + 34,5 giờ (tắt ANC, tắt RGB)
        - 10 + 30 giờ (tắt ANC, bật RGB)', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (335, 107, N'Tai nghe SteelSeries Arctis Nova 7 Wireless Dragon - Red/Gold - Limited Edition _ 61557', 5559000, 72, N'Description: 

Tai nghe SteelSeries Arctis Nova 7 Wireless Dragon - Red/Gold - Limited Edition - Phiên bản giới hạn đặc biệt siêu đẹp đến từ Steelseries để chào đón năm 2024 - Năm con Rồng.

Âm thanh cao cấp
Hệ thống Nova Acoustic đem lại chất lượng âm thanh cao, tương thích với các công nghệ âm thanh vòm, nâng cao chất lượng chơi game của bạn.



Tương thích với nhiều thiết bị
Với Dongle USB-C, tai nghe SteelSeries Arctis Nova 7 Wireless Dragon - Red/Gold - Limited Edition  dễ dàng tương thích với nhiều loại thiết bị như PC, Mac, PlayStation, or Switch, hoặc các thiết bị smartphone sử dụng cổng Type-C.

Thời lượng pin cao
Thoải mái sử dụng trong nhiều giờ liền với thời lượng pin cực cao cùng với công nghệ sạc nhanh.

Micro chất lượng cao

Hệ thống ComfortMax

Điều chỉnh dễ dàng


Detailed Specifications: 


• Kết nối: Wireless 2.4GHz / Bluetooth
• Micro: 
        - ClearCast Gen 2
        - Khử tiếng ồn 2 chiều
• Pin: 
        - 38 Giờ - 2.4GHz Quantum 2.0 Gaming Wireless
        - 26 Giờ - 2.4GHz Quantum 2.0 Gaming Wireless + Bluetooth
        - (Sạc nhanh USB-C15 phút cho 6 giờ chơi)
        - *Thời gian sử dụng có thể thay đổi tùy theo nhu cầu sử dụng.
• Trở kháng: Tai nghe: 36 Ohm
• Độ nhạy: 
        - Tai nghe:  93dBSPL
        - Micro: -38 db
• Tần số: 
        - Tai nghe:  20–22.000 Hz
        - Micro: 100-6500 Hz
• Neodymium Drivers: 40mm
• Tương thích: PC /  Mac / PS4, 5 / Nitendo / Mobile / Oculus Quest 2', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (336, 108, N'Tai nghe Gaming HP HyperX Cloud III Wireless BLK GAM HS', 3699000, 78, N'Description: 

Tai nghe Gaming HP HyperX Cloud III Wireless - Phiên bản tiếp theo nối tiếp sự thành công của phiên bản Cloud II Wireless trước đây. Thừa hưởng những yếu tố thiết kế đặc trưng, HyperX Cloud III tiếp nối cùng những cải tiến nâng cấp chất lượng đủ để mang đến những trải nghiệm chơi game cao cấp hơn đến từ HyperX.

Thời lượng pin cực cao
Thời lượng pin của HP HyperX Cloud III Wireless được nâng cấp cho thời lượng sử dụng lên đến 120h, giúp người dùng có thể thoải mái sử dụng cho các tác vụ chơi game hay giải trí lâu dài mà không lo hết pin.

Thiết kế thoải mái đặc trưng
Thừa hưởng phong cách thiết kế đặc trưng từ các phiên bản tiền nhiệm, HP HyperX Cloud III Wireless vẫn mang đến cho người dùng sự thoải mái đặc trưng, với phần mút hoạt tính đặc trưng của HyperX ở phần đệm tai và phần vòng chụp đầu được bọc trong miếng giả da mềm mại cao cấp, mang lại cảm giác vừa vặn thoải mái, cá tính sang trọng cho mọi hoàn cảnh.

Âm thanh sống động
Màng loa 53 mm kết hợp cùng với công nghệ âm thanh vòm DTS Headphone:X[2] đem đến trải nghiệm âm thanh vô cùng phong phú, đem lại sự chính xác trong việc định vị âm thanh, phù hợp cho đầy đủ các tác vụ giải trí trên chiếc PC của bạn.

Kết nối không dây ổn định
Sử dụng USB Adapter, HyperX Cloud III Wireless đem đến kết nối không dây 2.4Ghz cực kỳ ổn định, cùng với đó là sự tương thích với nhiều thiết bị giải trí, đem lại tính đa dụng cho chiếc tai nghe này.

Micro cao cấp có thể tháo rời
Mẫu micrô có khả năng khử ồn này trang bị màng lọc dạng lưới tích hợp sẵn, giúp giảm tạp âm hơn nữa, cung cấp chất lượng trò chuyện khi chơi game vô cùng tốt. Thiết bị còn có đèn LED báo hiệu trạng thái tắt tiếng micrô.

Bền bỉ
Với bộ khung nhôm chắc chắn, HyperX Cloud III Wireless mang lại sự bền bỉ bất chấp các tác động từ bên ngoài.


Detailed Specifications: 


• Thương hiệu: HyperX
• Tên sản phẩm: Cloud III WL
• Mã sản phẩm (Model): 77Z45AA
• Loại tai nghe: HEADPHONE
• Chất liệu: Nhựa/cao su
• Màu sắc: Đen
• LED: Không
• Kết nối: Không dây
• Âm thanh vòm: DTS Headphone:X Spatial Audio
• Kích thước màng loa (mm): 53
• Tần số đáp ứng (Hz): 10 - 21000 Hz
• Trở kháng: 64 Ohm
• Độ nhạy: 100 dB SPL', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (337, 109, N'Túi da đựng phụ kiện đa năng Wiwu Alpha Anti Thief Clurch', 309000, 64, N'Description: 

Túi da đựng phụ kiện đa năng Wiwu Alpha Anti Thief Clurch
Túi có thiết kế thời trang phù hợp với mọi lứa tuổi
Chất lượng da PU cao cấp cho khả năng chống nước
Khóa kéo mật khẩu an toàn và bảo mật
Tay xách được thiết kế bên mặt lưng cầm giữ dễ dàng và an toàn
Các ngăn được bố trí thông minh , có thể để được phụ kiện, điện thoại, tai nghe, tiền và thẻ card , pin dự phòng…
Kích thước : 26 x 17 x 7cm

Theo dõi HACOM nhiều hơn để cập nhật thêm nhiều bài viết hay ho hơn nữa! Hãy gọi ngay hotline 1900.1903 nếu có bất cứ câu hỏi hay thắc mắc nào mà các bạn cần giải đáp để được đội ngũ tư vấn viên trợ giúp nhé!


Detailed Specifications: 


• Thương hiệu: Wiwu
• Đặc tính: 
        - Túi có thiết kế thời trang phù hợp với mọi lứa tuổi
        - Chất lượng da PU cao cấp cho khả năng chống nước
        - Khóa kéo mật khẩu an toàn và bảo mật
        - Tay xách được thiết kế bên mặt lưng cầm giữ dễ dàng và an toàn
        - Các ngăn được bố trí thông minh , có thể để được phụ kiện, điện thoại, tai nghe, tiền và thẻ card , pin dự phòng…
        - Kích thước : 26 x 17 x 7cm', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (338, 109, N'Túi đựng phụ kiện đa năng Wiwu Cozy Storage Bag Gray', 209000, 30, N'

Detailed Specifications: 


• Thương hiệu: Wiwu
• Đặc tính: 
        - Chất liệu: vải chống thấm nước
        - Màu sắc: Xanh, đen, xám
        - Thiết kế có các ngăn để phụ kiện điện tử như cáp sạc, chuột, củ sạc, đồng hồ .....
        - Ngăn trong lưới tổ ong nhẹ, thoáng khí và đẹp mắt
        - Sử dụng dây thun có độ bền cao
        - Tay cầm bằng da sợi nhỏ
        - Kích thước: 20x14.5x7cm', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (339, 110, N'Hộp đựng phụ kiện Boona F002 vải Oxford màu đen', 79000, 14, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (340, 110, N'Hộp đựng phụ kiện Boona F002 vải Oxford màu xám', 79000, 84, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (341, 110, N'Hộp đựng phụ kiện Boona B009 vải Oxford màu đen', 109000, 87, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (342, 110, N'Hộp đựng phụ kiện Boona F001 Da màu đen', 79000, 57, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (343, 110, N'Hộp đựng phụ kiện Boona F001 Da màu xám', 79000, 26, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (344, 110, N'Hộp đựng phụ kiện Boona F001 Vải Oxford màu đen', 79000, 32, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (345, 110, N'Hộp đựng phụ kiện Boona B009 vải Oxford màu xám', 109000, 85, N'

Detailed Specifications: 


• Dòng sản phẩm: Túi đựng phụ kiện
• Hãng sản xuất: Boona
• Chất liệu: Da/Vải', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (346, 111, N'Giá đỡ laptop HyperWork L1 khung nhôm màu xám', 529000, 91, N'

Detailed Specifications: 


• Tên sản phẩm: Giá đỡ laptop HyperWork L1 khung nhôm
• Thương hiệu: HyperWork
• Màu: Xám
• Phù hợp với laptop: Từ 11 đến 17.3 inch
• Tùy chỉnh độ cao: 0-170 mm
• Kích thước: 252x223 mm
• Nặng: 850 g', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (347, 111, N'Giá đỡ laptop HyperWork L1 khung nhôm màu bạc', 529000, 46, N'

Detailed Specifications: 


• Tên sản phẩm: Giá đỡ laptop HyperWork L1 khung nhôm
• Thương hiệu: HyperWork
• Màu: Bạc
• Phù hợp với laptop: Từ 11 đến 17.3 inch
• Tùy chỉnh độ cao: 0-170 mm
• Kích thước: 252x223 mm
• Nặng: 850 g', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (348, 112, N'Đế tản nhiệt Laptop COOLER MASTER - CMC3', 189000, 22, N'Description: 

Tản nhiệt hiệu quả
Đế làm mát Laptop COOLER MASTER - CMC3 trang bị 1 quạt lớn có kích thước 20 cm có chức năng đẩy lượng không khí nóng ra ngoài và đẩy không khí từ môi trường có nhiệt độ thấp vào bên trong.

Khả năng sử dụng rộng
Đế làm mát Laptop COOLER MASTER - CMC3 thiết kế dành cho tất cả các dòng laptop có kích thước 14 đến 15 inch. Với chiếc đế tản nhiệt này, bạn sẽ không còn lo lắng chiếc máy tính của mình sẽ bị quá nóng khi sử dụng trong thời gian dài.

Kết nối đơn giản
Bạn không cần phải lấy bất cứ nguồn năng lượng ngoài nào, chỉ cần bạn kết nối sản phẩm với laptop qua cổng USB là quạt có thể chạy được. Không cần phải cài đặt bất cứ phần mềm nào, và tốn quá nhiều thời gian, bạn đã có thể làm mát cho chiếc máy tính của mình.

Chất liệu bền bỉ, cao cấp
Đế làm mát Laptop COOLER MASTER - CMC3 có cấu trúc làm từ nhựa cao cấp, có độ bền cao, cho tuổi thọ sử dụng dài lâu.


Detailed Specifications: 


• Dòng sản phẩm: Đế làm mát laptop
• Hãng sản xuất: COOLER MASTER
• Model: CMC3
• Sử dụng: Dùng làm giảm nhiệt độ cho laptop', 0, 0)
GO
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (349, 109, N'Cặp Laptop nữ 13,3 inch Wiwu Cosmo slim case màu xanh', 299000, 41, N'

Detailed Specifications: 


• Hãng sản xuất: Wiwu
• Kích thước chung: 13,3 Inch
• Chất liệu: Polyester
• Tính năng: Chống nước
• Khóa kéo: Chất liệu chống chịu tốt với khóa kéo cao cấp', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (350, 109, N'Cặp Laptop nữ 13,3 inch Wiwu Cosmo slim case màu hồng thẫm', 299000, 41, N'

Detailed Specifications: 


• Hãng sản xuất: Wiwu
• Kích thước chung: 13,3 Inch
• Chất liệu: Polyester
• Tính năng: Chống nước
• Khóa kéo: Chất liệu chống chịu tốt với khóa kéo cao cấp', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (351, 109, N'Cặp Laptop nữ 14 inch WiWu Vivi Handbag màu xanh', 249000, 67, N'

Detailed Specifications: 


• Hãng sản xuất: Wiwu
• Kích thước chung: 14 Inch
• Chất liệu: Polyester
• Tính năng: Chống nước
• Khóa kéo: Chất liệu chống chịu tốt với khóa kéo cao cấp', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (352, 109, N'Túi chống sốc WiWU Alpha Double Layer Sleeve 14 inch màu xám', 569000, 83, N'

Detailed Specifications: 


• Thương hiệu: WiWu
• Dòng sản phẩm: Balo, túi xách
• Chất liệu: Vải, chống sốc', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (353, 109, N'Túi chống sốc WiWU Alpha Double Layer Sleeve 14 inch màu đen', 569000, 39, N'

Detailed Specifications: 


• Thương hiệu: WiWu
• Dòng sản phẩm: Balo, túi xách
• Chất liệu: Vải, chống sốc', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (354, 109, N'Túi chống sốc laptop WIWU Minimalist Sleeve 14 inch _ Màu đen', 299000, 17, N'Description: 

Túi chống sốc Wiwu Minimalist Sleeve 14 inch là gợi ý lý tưởng giúp chiếc laptop của bạn được bảo vệ, hạn chế bị trầy xước hay nứt vỡ. Phụ kiện túi chống sốc Wiwu này còn có thiết kế đệm nhiều lớp bên trong và chống thấm bên ngoài cùng kiểu dáng thanh lịch, tôn lên vẻ đẹp sang trọng cho bạn.
Kiểu dáng thanh lịch, phù hợp với nhiều kích cỡ laptop
Túi chống sốc Wiwu Minimalist Sleeve 14 inch được sở hữu một thiết kế đơn giản, tông màu đen sang trọng cùng các đường may chính xác, tỉ mỉ. Kiểu dáng các góc cạnh vuông vắn cũng góp phần tạo nên xu hướng thời trang, tôn lên vẻ tinh tế cho người dùng kể cả nam hoặc nữ.

Chất liệu của túi chống sốc Wiwu Minimalist Sleeve này chính là vải Polyester chống thấm nước. Do đó, bề mặt ngoài của túi luôn giữ được độ sáng bóng, chống thấm nên không lo ảnh hưởng đến laptop bên trong.
Mặt khác, túi chống sốc Wiwu Minimalist Sleeve có kích thước vừa vặn với các thiết bị như laptop từ 154 inch trở xuống.
Bên trong lót lông chống xước, nhiều ngăn chứa tiện dụng
Không chỉ bảo vệ từ ngoài mà túi chống sốc Wiwu Minimalist Sleeve 14 inch còn giúp laptop hạn chế tình trạng xầy xước nhờ có lớp lót dày dặn. Lớp lót bên trong còn có khả năng thoát khí, nên không lo nhiệt độ làm ảnh hưởng đến laptop do để trong túi lâu.
Bên cạnh ngăn chính để đựng laptop, túi chống sốc này còn tích hợp thêm ngăn phụ ở trước để bạn có thể chứa thêm nhiều phụ kiện khác. Khóa kéo của ngăn chính còn là loại cao cấp, giúp đóng mở nhẹ nhàng và bền bỉ theo thời gian.


Detailed Specifications: 


• Thương hiệu: WiWu
• Dòng sản phẩm: Balo, túi xách, túi chống sốc
• Chất liệu: Vải, chống sốc', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (355, 113, N'Chai xịt vệ sinh laptop đa năng Handboss', 79000, 68, N'Description: 

Cách sử dụng:
Lắc đều bình và xịt trực tiếp vào các loại bàn phím laptop, PC ,...làm sạch mọi bụi bân, và mồ hôi tay lâu ngày két trên bề mặt vật dụng Tẩy các loại ghế đa,ghế nỉ,sofa,các loại mặt kính,mặt gỗ,bề mặt Alu,bếp ga,nồi cơm điện,có thể đánh rửa các loại giầy dạng nỉ,dạng vải Hương vị chanh, rất thơm và dễ chịu.


Tẩy các loại ghế đa,ghế nỉ,sofa,các loại mặt kính,mặt gỗ,bề mặt Alu,bếp ga,nồi cơm điện,có thể đánh rửa các loại giầy dạng nỉ,dạng vải Lắc đều bình và xịt trực tiếp vào các loại bàn phím laptop, PC ,...làm sạch mọi bụi bân, và mồ hôi tay lâu ngày két trên bề mặt vật dụng Hương vị chanh, rất thơm và dễ chịu


Sử dụng để vệ sinh bàn phím laptop ,máy tính ,màn hình ,máy in ,xe cộ ,
Sử dụng cụ kính ,bề mặt bằng da ,máy in ,photocopy ,máy say sinh tố ....Lắc đều bình và xịt trực tiếp vào các loại bàn phím laptop, PC ,...làm sạch mọi bụi bân, và mồ hôi tay lâu ngày két trên bề mặt vật dụng
Tẩy các loại ghế đa,ghế nỉ,sofa,các loại mặt kính,mặt gỗ,bề mặt Alu,bếp ga,nồi cơm điện,có thể đánh rửa các loại giầy dạng nỉ,dạng vải
Hương vị chanh, rất thơm và dễ chịu


Detailed Specifications: 


• Sản phẩm: Bộ vệ sinh Laptop
• Mô tả: 
        - Dùng để vệ sinh các loại bàn phím laptop,PC ,làm sạch mọi bụi bân, và mồ hôi tay lâu ngày két trên bề mặt bàn phím.
        - Tẩy các loại ghế đa,ghế nỉ,sofa,các loại mặt kính,mặt gỗ,bề mặt Alu,bếp ga,nồi cơm điện,có thể đánh rửa các loại giầy dạng nỉ,dạng vải.
        - Hương vị chanh, rất thơm và đễ chịu. .
• Cách sử dụng: 
        - 1, Lắc đều trước khi sử dụng, chất làm sạch được phun là một bọt.
        - 2, Phun đều lên bề mặt cần làm sạch,ở khoảng cách khoảng 20 cm
        - 3, Thoa đều lên bề mặt được làm sạch 30-40 giây.
        - 4, Dùng vải lau, hoặc miếng lau chuyên dụng. 5, Cuối cùng lau sạch bằng vải khô.', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (356, 111, N'Chai vệ sinh màn hình HyperWork HPW-C02 -Dạng xịt 245ml', 89000, 59, N'

Detailed Specifications: 


• Tên sản phẩm: Chai vệ sinh màn hình HyperWork HPW-C02
• Thương hiệu: HyperWork
• Thành phần: 
        - Coloamidopropyl betaine
        - Chelating agent 2066
        - 2-Methyl-1
        - 2-thiazol-3(2H)-one
        - 2-thiazol-3(2H)-one - 5-chloro-2-methyl-1
        - De-lonized Water
• Dung tích: 250 ml', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (357, 114, N'Sạc laptop HP 19V-4.74A-90W - Chân kim to - Củ hình chữ nhật', 229000, 79, N'Description: 

Giới thiệu sản phẩm Sạc laptop HP 19V-4.74A-90W - Chân kim to
Sạc laptop HP 19V-4.74A-90W - Chân kim to là sản phẩm vô cùng quan trọng cho Laptop. Để chiếc máy tính của mình hoạt động ổn định, người dùng cần sở hữu một bộ cấp nguồn chất lượng, ổn định, cung cấp điện năng liên tục cho Laptop. Giữa hàng ngàn sản phẩm kém chất lượng đang trôi nổi trên thị trường, Sạc laptop HP 19V-4.74A-90W - Chân kim to với chất lượng đã được đảm bảo sẽ là sự lựa chọn đem lại an tâm cho người sử dụng.
ĐẶC ĐIỂM SẢN PHẨM
Sạc laptop HP 19V-4.74A-90W - Chân kim to có điện áp vào là 100 – 240V với điện áp đầu ra là 19.0V – 4.74A tương thích với nhiều loại Laptop HP trên thị trường. Đầu cắm của sản phẩm là đầu thường nhỏ tròn đường kính 5.5 mm, đường kính lỗ 2.5 mm. Sản phẩm có màu đen với thông số ghi trên thân nguồn. Để sử dụng, người dùng cần một dây cắm 2 chân kết nối với Sạc laptop HP 19V-4.74A-90W - Chân kim to. Vỏ bọc dây của làm từ chất liệu nhựa cao cấp, bền chặt, chống rò điện. cách nhiệt.

Sản phẩm cung cấp điện năng ổn định, chống cháy nổ, tuổi thọ sử dụng rất lâu. Sạc laptop HP 19V-4.74A-90W - Chân kim to là sự lựa chọn chất lượng, an toàn, giá thành quá rẻ so với hiệu năng của sản phẩm.
LƯU Ý KHI MUA SẠC LAPTOP:
Tìm mua bộ sạc dựa trên model của laptop
Tìm mua bộ sạc dựa trên chỉ số điện năng và giắc cắm tương ứng


Detailed Specifications: 


• Dòng sản phẩm: Sạc
• Sử dụng: Dùng thay thế cho sạc Laptop cũ, hỏng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (358, 114, N'Sạc Laptop HP 19.5V-3.33 65W Chân kim nhỏ, củ hình chữ nhật', 259000, 31, N'

Detailed Specifications: 


• Thương hiệu: HP
• Điện áp ra: 19.5V - 3.33A
• Chân cắm: Kim nhỏ', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (359, 90, N'Sạc Laptop Acer 19V - 2.37A chân nhỏ 3.0*1.1/1.0', 259000, 83, N'

Detailed Specifications: 


• Sản phẩm: Sạc laptop
• Dùng cho máy: Acer
• Điện áp vào: 100V-240V
• Điện áp ra: 19.5V - 2.37A
• Loại chân cắm: Đầu kim nhỏ', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (360, 115, N'Bộ Chia USB Orico H7013-BK', 549000, 57, N'Description: 

Đặc điểm nổi bật của bộ Chia USB Orico H7013-BK
Hub usb Orico kết nối mở rộng cùng lúc 7 cổng USB 3.0
Nguồn ngoài 5V - 2A cung cấp điện ổn định cho mỗi cổng usb, cho phép kết nối đáng tin cậy các thiết bị của bạn
Tốc độ truyền lên đến 5Gbps, nhanh hơn USB 2.0 gấp tới 10 lần, hiệu suất tốt nhất và khả năng tương thích
Tương thích với các chuẩn USB 2.0 và 1.1 trên các thiết bị cũ
kết nối mọi thiết bị kỹ thuật số như: máy ảnh, iphone, ipad, USB, cắm sạc điện thoại, I
Tích hợp và Chạy trên các hệ điều hành: Windows, IOS, L
Cắm vào là sử dụng được luôn, ko cần cài đặt phần mềm nào nữa.


Detailed Specifications: 


• Mã sản phẩm: H7013-U3-AD
• Mô tả: 
        - Bộ chia USB HUB 7 cổng USB 3.0
        - Đầu vào (input): Cáp 1m USB 3.0
        - Đầu ra (output): 7 cổng USB 3.0 Type A. Có Adaptor
        - Màu: BK: Màu đen, WH: Trắng, RD: Đỏ, BL: Xanh, GY: Xám.
        - Cáp dài 1m thích hợp cho máy để bàn.', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (361, 115, N'Bộ Chia USB Orico W5PH4 BK', 259000, 78, N'Description: 

Đặc điểm nổi bật của bộ Chia USB Orico W5PH4 BK
Orico W5PH4-U3 (Chia 1 cổng USB ra 4 cổng USB): giao tiếp USB 3.0 tốc độ max 5Gb/s.
Hỗ trợ hot-swap, plug; play.
Thiết kế nhỏ gon, dễ dàng mang theo (không cần nguồn phụ).
Sử dụng gắn 4 thiết bị USB vào máy tính để truy cập hoặc sạc pin; các thiết bị USB như: ổ cứng gắn ngoài, máy ảnh kỹ thuật số, usb flash, máy
Hỗ trợ 1TB ổ cứng ngoài và các thiết bị USB khác.


Detailed Specifications: 


• Mã sản phẩm: W5PH4-U3
• Mô tả: 
        - Bộ chia USB HUB 4 cổng USB 3.0
        - USB 3.0, tốc độ truyền dữ liệu 5Gbps. Tốc độ nhanh hơn 10 lần so với 2.0
        - Đầu vào (input): 1 cáp: USB 3.0 dài 0,3m
        - Đầu ra (output): 4 cổng USB 3.0
        - Có đèn LED
        - Các màu: BK: Màu đen, WH: Trắng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (362, 116, N'Bộ Chia HDMI 1 ra 4 Ugreen UG-40202', 899000, 97, N'Description: 

Đặc điểm nổi bật của bộ Chia HDMI 1 ra 4 Ugreen UG-40202













Bộ chuyển HDMI 1 ra 4 hỗ trợ chia từ máy tính PC/laptop/máy chiếu ra 4 màn hình TV. Độ phân giải cao hỗ trợ full HD
Cho phép người dùng kết nối bất kỳ nguồn video, chẳng hạn như: DVD, truyền hình vệ tinh, cáp Box, PC, Xbox, PS3 và nhiều hơn nữa với lên đến 4 màn hình HDMI kỹ thuật số.
Bộ chia 1 máy tính ra 4 màn hình TV hỗ trợ kết nối 1 nguồn phát ra 4 màn hiển thị cùng lúc
Video màu sâu lên đến 12bit, 1080p @ (24/50/60) Hz 1920x1200
Bộ chia HDMI được sử dụng cho ngành công nghiệp truyền hình độ nét cao, kỹ thuật hoạt động trong lĩnh vực truyền hình vệ tinh, giám sát trung tâm dữ liệu, giáo dục, đào tạ
Dễ dàng sử dụng, chỉ cần lắp đặt, kết nối dây cáp tín hiệu xong là có thể sử dụng, không cần cài đặt driver hay phần mềm hỗ trợ nào khác
Vật liệu kim loại bền chắc
Thiết kế lỗ tản nhiệt bảo vệ cho thiết bị
Hỗ trợ nguồn DC-5V
Hỗ trợ độ phân giải 3D, 2K*4K.


Detailed Specifications: 


• Thương hiệu: Ugreen
• Model: UG-40202
• Tín hiệu đầu vào: 01 x HDMI (âm)
• Tín hiệu đầu ra: 4 Cổng HDMI (âm)
• Độ dài: NA
• Tốc độ truyền tải: 
        - Hỗ trợ hdmi 1.4v, 3D, độ phân giải cao nhất hỗ trợ 1080p/60hz
        - Truyền tốc độ cao, nhanh nhất tốc độ truyền dữ liệu 6,75 Gbps, không có sự chậm trễ, không chậm chạp.
        - Hỗ trợ độ phân giải: 24/50/60hz@480i/480p. 720i/720p. 1080i/1080p
• Màu sắc: Đen', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (363, 117, N'Thiết bị kết nối Bluetooth 5.0 TP-Link UB500', 139000, 12, N'Description: 

Trang Bị Máy Tính Bạn với Bluetooth 5.0
Bộ chuyển đổi USB Nano Bluetooth 5.0


Bluetooth 5.0: Tốc Độ Nhanh Hơn,Phủ Sóng Xa Hơn
UB500 trang bị cho PC của bạn công nghệ Bluetooth 5.0 tiên tiến giúp nâng cấp toàn diện so với các phiên bản cũ. Thiết bị chạy tốc độ kết nối nhanh hơn và phạm vi xa hơn so với công nghệ Bluetooth 5.0, đảm bảo kết nối không dây mạnh mẽ và ổn định giữa PC và các thiết bị Bluetooth của bạn. Người dùng cũng được hưởng lợi từ việc tiết kiệm năng lượng và công suất phát sóng lớn hơn.*

Nghe Nhạc Xuyên Suốt Trong Phòng
Nhờ những cải tiến Bluetooth, UB500 có phạm vi truyền xa hơn giữa các thiết bị như máy nghe nhạc và PC của bạn. Với khoảng cách truyền xa hơn, âm thanh qua tai nghe Bluetooth của bạn mượt mà hơn mà không cần di chuyển xung quanh máy tính của bạn. Giờ đây, bạn không cần phải lo lắng về khoảng cách ảnh hưởng đến việc nghe nhạc của mình.

Kết Nối Với Máy Tính Của Bạn Qua Bluetooth
UB500 giúp PC và laptop không có Bluetooth trở thành thiết bị có khả năng kết nối Bluetooth. Chỉ cần kết nối thiết bị Bluetooth của bạn với PC và tận hưởng một cách dễ dàng. Thiết bị hỗ trợ tối đa 7 thiết bị Bluetooth với kết nối không dây mạnh mẽ. Bạn có thể truyền tập tin, nhạc, video giữa các thiết bị Bluetooth và PC của mình với tốc độ truyền nhanh hơn gấp 2 lần.*

Kích thước Nano - Nhỏ Gọn, Tiện Lợi
Thiết kế kiểu dáng đẹp, siêu nhỏ giúp bạn có thể cắm bộ chuyển đổi nano vào bất kỳ cổng USB nào và chỉ cần giữ nó ở đó — bất kể bạn đang đi du lịch hay ở nhà.

Hỗ trợ Win 7, Win 8.1, Win 10, và Win 11


Detailed Specifications: 


• Chuẩn và Giao thức: Bluetooth 5.0
• Giao diện: USB 2.0
• Dimensions: 0.58 × 0.27 × 0.74 in (14.8 × 6.8 × 18.9 mm)
• Sản phẩm bao gồm: 
        - Bộ chuyển đổi USB Nano Bluetooth 5.0 UB500
        - Hướng dẫn cài đặt nhanh
• System Requirements: Hệ điều hành được hỗ trợ bao gồm Win 11/10/8.1/7
• Môi trường: 
        - Nhiệt độ hoạt động: 0℃~40℃ (32℉ ~104℉)
        - Độ ẩm hoạt động: 10%~90% không ngưng tụ
        - Độ ẩm lưu trữ: 5%~90% không ngưng tụ', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (364, 118, N'Ổ cắm điện đa năng LDNIO SC10610 - 10 chấu + 05 cổng USB-A + 01 cổng Type-C - Chuẩn chân cắm EU - Màu trắng', 409000, 51, N'Description: 

Ổ cắm đa năng LDNIO SC10610 phổ biến tại thị trường EU nay đã xuất hiện tại hệ thống của HACOM với mức giá hợp lý để ai cũng có thể tiếp cận

Tiện dụng trong mọi tình huống

Sạc nhanh cho Android và các thiết bị Apple

Thiết kế thông minh cho góc làm việc ngăn nắp

Cấu tạo từ vật liệu an toàn cao

Chân cắm chuẩn EU

Hoàn hảo cho các thiết bị di động & PC

Dây nguồn dầy dặn

Chân đế chống trượt

Vật liệu tiêu chuẩn EU

Chế tạo hoàn toàn trên dây chuyền tự động

Tiện dụng cho cuộc sống hàng ngày

Loại bỏ những nguy cơ gây mất an toàn

Thông số

Đóng gói


Detailed Specifications: 


• Thương hiệu: LDNIO
• Phân loại: Ổ cắm điện đa năng
• Đầu ra: 10 chấu + 5 cổng sạc USB-A + 1 cổng Type C
• Công suất: Tối đa 2500W
• Độ dài dây cắm: 2m
• Tiêu chuẩn: 
        - Đạt các tiêu chuẩn an toàn để xuất vào thị trường EU
        - Phù hợp với chuẩn chân cắm và các thiết bị điện gia dụng ở Việt Nam.
• Màu sắc: Trắng', 0, 0)
INSERT [dbo].[Products] ([id], [brandID], [name], [price], [stock], [description], [isDeleted], [isLaptop]) VALUES (365, 116, N'Cáp HDMI 15m Ugreen 40416, chuẩn 2.0', 899000, 25, N'

Detailed Specifications: 


• Thương hiệu: Ugreen
• Tên sản phẩm: Cáp HDMI 15m
• Model: 40416
• Độ dài: 15M
• Tốc độ truyền tải: 
        - Tốc độ truyền dữ liệu: 10,2 Gb/s
        - Hỗ trợ tối đa 32 kênh âm thanh kỹ thuật số không nén (HDMI 1.4 chỉ hỗ trợ 8 kênh)
        - Cáp được cấu tạo từ lõi làm bằng đồng nguyên chất, đầu HDMI được mạ vàng 24k, có chữ Ugreen in nổi ở hai đầu jack cắm
        - Hỗ trợ âm thanh Dolby TrueHD và DTS-HD Master Audio , HDCP compliant
        - Hỗ trợ HDCP compliant, HDMI Ethernet Channel, Ethernet, 3D, 4K
        - Cáp tín hiệu HDMI 2.0 - Hỗ trợ độ phân giải 4K*2K - Cho phép độ phân giải video lên đến 4096x2160p vượt xa 1080p, hỗ trợ màn hình thế hệ tiếp theo sẽ cạnh tranh với hệ thống Digital Cinema sử dụng trong nhiều rạp chiếu phim thương mại', 0, 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[LaptopCPUSeries] ON 

INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (29, 87, N'Core i5')
INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (30, 87, N'Core i7')
INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (31, 91, N'Ryzen 5')
INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (32, 91, N'Ryzen 9')
INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (33, 91, N'Ryzen 7')
INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (34, 87, N'Core Ultra 9')
INSERT [dbo].[LaptopCPUSeries] ([id], [manufacturerID], [name]) VALUES (35, 87, N'Core i9')
SET IDENTITY_INSERT [dbo].[LaptopCPUSeries] OFF
GO
SET IDENTITY_INSERT [dbo].[LaptopGPUSeries] ON 

INSERT [dbo].[LaptopGPUSeries] ([id], [manufacturerID], [name]) VALUES (24, 88, N'RTX 30')
INSERT [dbo].[LaptopGPUSeries] ([id], [manufacturerID], [name]) VALUES (25, 88, N'RTX 20')
INSERT [dbo].[LaptopGPUSeries] ([id], [manufacturerID], [name]) VALUES (26, 88, N'RTX 40')
INSERT [dbo].[LaptopGPUSeries] ([id], [manufacturerID], [name]) VALUES (27, 87, N'Iris Xe')
SET IDENTITY_INSERT [dbo].[LaptopGPUSeries] OFF
GO
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (250, 29, 24, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (251, 29, 25, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (252, 29, 25, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (253, 30, 25, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (254, 31, 26, 15.6, N'1920x1080', N'16:9', 1, 1000, 60, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (255, 30, 26, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (256, 32, 26, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (257, 31, 25, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (258, 30, 27, 15.6, N'1920x1080', N'16:9', 1, 1000, 165, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (259, 30, 26, 16, N'1920x1080', N'16:9', 1, 512, 165, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (260, 30, 26, 16, N'1920x1080', N'16:9', 1, 512, 240, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (261, 33, 26, 15.6, N'1920x1080', N'16:9', 1, 1000, 144, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (262, 34, 26, 16, N'1920x1080', N'16:9', 1, 1000, 240, 32)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (263, 29, 24, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (264, 31, 24, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (265, 29, 24, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (266, 30, 26, 16, N'1920x1080', N'16:9', 0, 1000, 240, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (267, 29, 24, 15.6, N'1920x1080', N'16:9', 1, 512, 144, 12)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (268, 30, 27, 14, N'1920x1080', N'16:9', 1, 512, 60, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (269, 30, 27, 16, N'1920x1080', N'16:9', 1, 512, 60, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (270, 33, 24, 16, N'1920x1080', N'16:9', 1, 512, 120, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (271, 30, 24, 16, N'1920x1080', N'16:9', 1, 1000, 120, 32)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (272, 35, 26, 15.6, N'1920x1080', N'16:9', 1, 512, 120, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (273, 35, 26, 16, N'1920x1080', N'16:9', 1, 2000, 120, 64)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (274, 30, 26, 17, N'1920x1080', N'16:9', 1, 2000, 165, 32)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (275, 30, 26, 16, N'1920x1080', N'16:9', 1, 512, 144, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (276, 30, 25, 16, N'1920x1080', N'16:9', 1, 1000, 60, 32)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (277, 29, 27, 16, N'1920x1080', N'16:9', 1, 512, 60, 16)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (278, 29, 27, 14, N'1920x1080', N'16:9', 1, 256, 60, 8)
INSERT [dbo].[Laptops] ([productID], [cpuSeries], [gpuSeries], [screenSize], [screenResolution], [screenAspectRatio], [storageType], [storageSize], [refreshRate], [ram]) VALUES (279, 35, 25, 16, N'1920x1080', N'16:9', 1, 1000, 60, 32)
GO
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (250, 0, N'8DC86D07CB32192+22F9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (250, 1, N'8DC86D07CC10560+2300')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (250, 2, N'8DC86D07CC3D700+22FF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (251, 0, N'8DC86D07D2D1613+37E0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (251, 1, N'8DC86D07D306874+22B9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (251, 2, N'8DC86D07D34C462+22B8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (252, 0, N'8DC86D07DAE3B3A+251D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (252, 1, N'8DC86D07DB29CA2+1C0C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (252, 2, N'8DC86D07DB6529B+2521')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (253, 0, N'8DC86D07E2F65F5+2535')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (253, 1, N'8DC86D07E3410A1+1C0D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (253, 2, N'8DC86D07E382255+2534')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (254, 0, N'8DC86D07EABE002+2322')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (254, 1, N'8DC86D07EB00881+2321')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (254, 2, N'8DC86D07EB360E6+2327')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (255, 0, N'8DC86D07F1EEEDB+1954')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (255, 1, N'8DC86D07F2302DC+1959')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (255, 2, N'8DC86D07F271116+1958')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (256, 0, N'8DC86D07FC7A2B0+22C8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (256, 1, N'8DC86D07FCBE0AD+22CC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (256, 2, N'8DC86D07FCF798D+22CB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (257, 0, N'8DC86D08042C882+22A2')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (257, 1, N'8DC86D08047B6FB+22A1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (257, 2, N'8DC86D0804AA509+22D1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (258, 0, N'8DC86D0810B042A+2664')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (258, 1, N'8DC86D0810F6AB3+266A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (258, 2, N'8DC86D081123555+2669')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (259, 0, N'8DC86D081AB98F3+25C1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (259, 1, N'8DC86D081B00F3B+25BF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (259, 2, N'8DC86D081B2D99A+258F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (260, 0, N'8DC86D0826357B2+2367')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (260, 1, N'8DC86D082677756+23FF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (260, 2, N'8DC86D0826B2651+23FE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (261, 0, N'8DC86D082ECABFF+22B5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (261, 1, N'8DC86D082F0BA35+22B4')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (261, 2, N'8DC86D082F44A53+22B9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (262, 0, N'8DC86D0837FD933+26BB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (262, 1, N'8DC86D08388363F+1A55')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (262, 2, N'8DC86D0838DEF2B+26C2')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (263, 0, N'8DC86D084066B04+19E3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (263, 1, N'8DC86D0840DC987+19E0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (263, 2, N'8DC86D08410DCF6+19E1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (264, 0, N'8DC86D0846304B9+2297')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (264, 1, N'8DC86D084682D60+2295')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (264, 2, N'8DC86D0846C4876+229B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (265, 0, N'8DC86D08529A7DA+1D34')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (265, 1, N'8DC86D0852CE217+2552')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (265, 2, N'8DC86D085314C0B+2591')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (266, 0, N'8DC86D085A41DEF+239F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (266, 1, N'8DC86D085A8D5CC+24ED')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (266, 2, N'8DC86D085ABD339+24F0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (267, 0, N'8DC86D0861DA149+2299')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (267, 1, N'8DC86D08621F2D0+2297')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (267, 2, N'8DC86D08624C3D2+229D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (268, 0, N'8DC86D086F4D23C+1BCC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (268, 1, N'8DC86D086F824D9+1BC7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (268, 2, N'8DC86D086FAE058+1BC9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (269, 0, N'8DC86D087EB7DD0+1EB8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (269, 1, N'8DC86D087EFD513+1BCF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (269, 2, N'8DC86D087F31922+1BCE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (270, 0, N'8DC86D08951E165+281B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (270, 1, N'8DC86D089567C98+2819')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (270, 2, N'8DC86D0895A6D34+281F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (271, 0, N'8DC86D08B791CB4+211D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (271, 1, N'8DC86D08B7CF4F3+21B0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (271, 2, N'8DC86D08B8053B1+21AF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (272, 0, N'8DC86D08C7254C9+1D97')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (272, 1, N'8DC86D08C763A94+1D96')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (272, 2, N'8DC86D08C793566+1D95')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (273, 0, N'8DC86D08CE64A2B+1CA5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (273, 1, N'8DC86D08CE99B4F+1CA4')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (273, 2, N'8DC86D08CECB285+1CA3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (274, 0, N'8DC86D08D59C7CA+20DD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (274, 1, N'8DC86D08D5D5446+20DC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (274, 2, N'8DC86D08D60459F+20DB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (275, 0, N'8DC86D08DF98104+1E9B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (275, 1, N'8DC86D08DFCEA75+1E9A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (275, 2, N'8DC86D08DFFECEB+1E99')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (276, 0, N'8DC86D08EA97B66+1EC8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (276, 1, N'8DC86D08EAE1995+1EC7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (276, 2, N'8DC86D08EB17C77+1EF7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (277, 0, N'8DC86D08F2E4503+190A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (277, 1, N'8DC86D08F328AC3+1909')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (277, 2, N'8DC86D08F366D06+1908')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (278, 0, N'8DC86D09058BE2D+1C2E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (278, 1, N'8DC86D0905C1A4C+1C2D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (278, 2, N'8DC86D0905FB896+1C2C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (279, 0, N'8DC86D091F64F3E+2769')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (279, 1, N'8DC86D091FAC736+276E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (279, 2, N'8DC86D091FE88B8+276D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (280, 0, N'8DC86D092EB7F25+37DC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (280, 1, N'8DC86D092F009DD+37DD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (280, 2, N'8DC86D092F3D80A+37DE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (281, 0, N'8DC86D09399E683+2F3F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (281, 1, N'8DC86D0939ED414+2F40')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (281, 2, N'8DC86D093A268F6+2F41')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (282, 0, N'8DC86D09402F195+2AD2')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (282, 1, N'8DC86D09408362F+2AD3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (282, 2, N'8DC86D0940C9D0D+2AD4')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (283, 0, N'8DC86D094A13E1B+31B2')
GO
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (283, 1, N'8DC86D094A83940+31B3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (283, 2, N'8DC86D094B60277+31B4')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (284, 0, N'8DC86D0950B95C5+29B9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (284, 1, N'8DC86D09510CE62+29BB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (284, 2, N'8DC86D095154643+29BC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (285, 0, N'8DC86D0958DC281+2C3E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (285, 1, N'8DC86D095920B28+2C3F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (286, 0, N'8DC86D0960CE430+209B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (286, 1, N'8DC86D09610DCB1+2099')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (286, 2, N'8DC86D09614A71D+209D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (287, 0, N'8DC86D0966E413D+2CB5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (288, 0, N'8DC86D09707BF33+2D31')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (288, 1, N'8DC86D0970BBD20+2D2F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (288, 2, N'8DC86D0970F46B0+2D2D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (289, 0, N'8DC86D0977BD4EF+1FAD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (289, 1, N'8DC86D0977F7752+1FB3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (289, 2, N'8DC86D097842F14+1FB1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (290, 0, N'8DC86D097EC9FF0+2C86')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (291, 0, N'8DC86D09862B1F6+2818')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (291, 1, N'8DC86D098672E19+2819')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (291, 2, N'8DC86D0986BB111+281A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (292, 0, N'8DC86D09CE0D409+2D70')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (292, 1, N'8DC86D09CE42588+2D72')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (292, 2, N'8DC86D09CE708D0+2D6E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (293, 0, N'8DC86D09DE44FBC+2C2B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (293, 1, N'8DC86D09DEB6A1B+2C35')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (293, 2, N'8DC86D09DEF4281+2C29')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (294, 0, N'8DC86D09E5DDCD3+28D7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (294, 1, N'8DC86D09E6135A7+28CF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (294, 2, N'8DC86D09E643D5C+28D9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (295, 0, N'8DC86D09EBDD007+3145')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (295, 1, N'8DC86D09EC15A1F+314A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (295, 2, N'8DC86D09EC46B53+3147')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (296, 0, N'8DC86D09F2508CF+29B5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (296, 1, N'8DC86D09F29033A+29B9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (296, 2, N'8DC86D09F2BE4A3+29BB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (297, 0, N'8DC86D09F9132E1+329B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (297, 1, N'8DC86D09F948EA3+32A0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (297, 2, N'8DC86D09F972BEB+329D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (298, 0, N'8DC86D0A004F53A+278D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (298, 1, N'8DC86D0A009120F+278F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (298, 2, N'8DC86D0A00C67E3+2789')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (299, 0, N'8DC86D0A087838D+2938')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (299, 1, N'8DC86D0A08B6645+293A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (299, 2, N'8DC86D0A08E8208+2934')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (300, 0, N'8DC86D0A0F1C8FE+2FC8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (300, 1, N'8DC86D0A0F67196+2FC9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (300, 2, N'8DC86D0A0FAA482+2FCA')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (301, 0, N'8DC86D0A1762D4D+2521')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (302, 0, N'8DC86D0A2269966+34D1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (302, 1, N'8DC86D0A22B5357+34D2')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (303, 0, N'8DC86D0A296AEF2+374B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (304, 0, N'8DC86D0A33A86C9+2851')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (304, 1, N'8DC86D0A33EAE8D+36CC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (304, 2, N'8DC86D0A342EC53+36D1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (305, 0, N'8DC86D0A3B08650+2DFB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (305, 1, N'8DC86D0A3D40BF2+2DF7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (305, 2, N'8DC86D0A3D7AEFB+2DFD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (306, 0, N'8DC86D0A43B3A15+3245')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (306, 1, N'8DC86D0A43FC55C+3247')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (306, 2, N'8DC86D0A4442964+3244')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (307, 0, N'8DC86D0A4A5B33C+27FC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (307, 1, N'8DC86D0A4AA7BBE+27FD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (307, 2, N'8DC86D0A4AED2FD+27FE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (308, 0, N'8DC86D0A51FF046+2AA4')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (308, 1, N'8DC86D0A542F53C+2AA5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (308, 2, N'8DC86D0A546838C+2AA6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (309, 0, N'8DC86D0A59A9B45+276D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (309, 1, N'8DC86D0A59E88A4+2773')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (309, 2, N'8DC86D0A5A20D15+276F')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (310, 0, N'8DC86D0A62B3889+1F09')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (310, 1, N'8DC86D0A6303282+1F0B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (310, 2, N'8DC86D0A634027D+1F07')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (311, 0, N'8DC86D0A6A3713A+192A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (311, 1, N'8DC86D0A6A77E20+1FDD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (311, 2, N'8DC86D0A6AA2035+1929')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (312, 0, N'8DC86D0A8452B44+2750')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (312, 1, N'8DC86D0A848698D+2750')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (312, 2, N'8DC86D0A84B1746+2750')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (313, 0, N'8DC86D0A8D0B274+2890')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (313, 1, N'8DC86D0A8D52300+2891')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (313, 2, N'8DC86D0A8D8BFCD+2892')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (314, 0, N'8DC86D0A94D35A2+1EDC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (314, 1, N'8DC86D0A950D448+27FE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (315, 0, N'8DC86D0A9B7B15E+244B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (315, 1, N'8DC86D0A9BACC37+244D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (315, 2, N'8DC86D0A9BD40E2+2BE7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (316, 0, N'8DC86D0AA184A0C+2474')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (316, 1, N'8DC86D0AA1B4D8D+2470')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (316, 2, N'8DC86D0AA1DCAB6+2472')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (317, 0, N'8DC86D0AA7BF21C+23A4')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (317, 1, N'8DC86D0AA7FAC21+23A6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (317, 2, N'8DC86D0AA82F0B7+23A8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (318, 0, N'8DC86D0AAEF0AE5+37E6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (318, 1, N'8DC86D0AAF3CF1C+37E9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (318, 2, N'8DC86D0AAF8416B+37E5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (319, 0, N'8DC86D0AB7EFB50+30D9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (319, 1, N'8DC86D0AB83146C+30D7')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (319, 2, N'8DC86D0AB87CF71+30E1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (320, 0, N'8DC86D0ABE983AE+3002')
GO
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (320, 1, N'8DC86D0ABEDADA5+3000')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (320, 2, N'8DC86D0ABF42DCB+2FFE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (321, 0, N'8DC86D0AC6F4752+2916')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (321, 1, N'8DC86D0AC732953+2917')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (321, 2, N'8DC86D0AC76DA41+2918')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (322, 0, N'8DC86D0ACEDCD54+29FE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (322, 1, N'8DC86D0ACF326EF+2A01')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (322, 2, N'8DC86D0ACF7ABC8+2A00')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (323, 0, N'8DC86D0AD632FBD+2830')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (323, 1, N'8DC86D0AD67013B+2831')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (323, 2, N'8DC86D0AD6A7610+2832')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (324, 0, N'8DC86D0ADEC7C0D+1CF8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (325, 0, N'8DC86D0AE7D670E+1E79')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (325, 1, N'8DC86D0AE8142EA+1E7A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (325, 2, N'8DC86D0AE848707+1E7B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (326, 0, N'8DC86D0AEE6A7F0+250B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (326, 1, N'8DC86D0AEEAC0BA+25A2')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (326, 2, N'8DC86D0AEEDB66A+259C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (327, 0, N'8DC86D0AF71B294+2928')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (327, 1, N'8DC86D0AF76375A+292E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (327, 2, N'8DC86D0AF7A702C+292C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (328, 0, N'8DC86D0AFECF6E6+1AD1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (328, 1, N'8DC86D0AFF0E358+269C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (328, 2, N'8DC86D0AFF436C5+269A')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (329, 0, N'8DC86D0B05C68CC+2BC1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (329, 1, N'8DC86D0B060497D+2BC3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (329, 2, N'8DC86D0B0636711+2BBF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (330, 0, N'8DC86D0B0ED8F7F+1FCF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (330, 1, N'8DC86D0B0F1797B+1FCD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (330, 2, N'8DC86D0B0F532BE+1FCB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (331, 0, N'8DC86D0B1564502+259C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (331, 1, N'8DC86D0B159D491+25A0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (331, 2, N'8DC86D0B15DE355+259E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (332, 0, N'8DC86D0B1DC6D79+1F54')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (332, 1, N'8DC86D0B1E1DA87+1F57')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (332, 2, N'8DC86D0B1E62474+1F56')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (333, 0, N'8DC86D0B2478585+28EB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (333, 1, N'8DC86D0B24B98AB+28ED')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (333, 2, N'8DC86D0B24ED77E+28F5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (334, 0, N'8DC86D0B29DD4B3+32E0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (334, 1, N'8DC86D0B2A1BE16+32E1')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (335, 0, N'8DC86D0B2F43A64+34AB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (335, 1, N'8DC86D0B2F8D7A0+34AD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (335, 2, N'8DC86D0B2FD7D76+34AE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (336, 0, N'8DC86D0B3501B77+2CDA')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (336, 1, N'8DC86D0B3545D47+2CDB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (336, 2, N'8DC86D0B3584D36+2CDC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (337, 0, N'8DC86D0B3F6EE53+1F74')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (337, 1, N'8DC86D0B3FB2C0A+1F75')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (337, 2, N'8DC86D0B3FEB126+1F73')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (338, 0, N'8DC86D0B46271F4+2A18')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (338, 1, N'8DC86D0B467E8C9+2A19')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (339, 0, N'8DC86D0B50526F7+2AA6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (339, 1, N'8DC86D0B50A632E+2AA5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (340, 0, N'8DC86D0B5724462+2AB6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (340, 1, N'8DC86D0B577F203+2AB5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (341, 0, N'8DC86D0B5F65F11+2D43')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (341, 1, N'8DC86D0B5FB91E6+2D44')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (342, 0, N'8DC86D0B661AE6C+28DF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (342, 1, N'8DC86D0B666AEFE+28DE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (343, 0, N'8DC86D0B6C48A7B+29AD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (343, 1, N'8DC86D0B6C97F46+29AC')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (344, 0, N'8DC86D0B74A118F+2C4D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (344, 1, N'8DC86D0B74F55E9+2C4C')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (345, 0, N'8DC86D0B7C949AD+2D54')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (345, 1, N'8DC86D0B7CF39AE+2D53')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (346, 0, N'8DC86D0B8D66B29+1BB8')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (346, 1, N'8DC86D0B8DA50C0+1BB6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (346, 2, N'8DC86D0B8DECF3D+1BB5')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (347, 0, N'8DC86D0B9410CA6+1BBF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (347, 1, N'8DC86D0B944B554+1BBE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (347, 2, N'8DC86D0B9497471+1BBD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (348, 0, N'8DC86D0B9B9FAE5+2463')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (349, 0, N'8DC86D0BA5536B7+287E')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (350, 0, N'8DC86D0BAFA702F+2A85')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (351, 0, N'8DC86D0BB760201+269D')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (352, 0, N'8DC86D0BC395222+2056')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (352, 1, N'8DC86D0BC3F5AD4+2051')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (352, 2, N'8DC86D0BC43EA41+2050')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (353, 0, N'8DC86D0BCAFC735+2052')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (353, 1, N'8DC86D0BCB42F6F+2051')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (353, 2, N'8DC86D0BCB8AA4B+2050')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (354, 0, N'8DC86D0BD3B9109+2959')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (354, 1, N'8DC86D0BD514CFA+2956')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (354, 2, N'8DC86D0BD62DDDB+2957')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (355, 0, N'8DC86D0BE93827D+2614')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (355, 1, N'8DC86D0BE97225C+2615')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (356, 0, N'8DC86D0C012EDF5+2627')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (356, 1, N'8DC86D0C0164FFD+2A22')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (356, 2, N'8DC86D0C01BA259+2A21')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (357, 0, N'8DC86D0C1F87AA2+2D9B')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (357, 1, N'8DC86D0C1FB98C5+1DCF')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (357, 2, N'8DC86D0C1FF7717+1DCE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (358, 0, N'8DC86D0C281886B+29CB')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (358, 1, N'8DC86D0C28569D0+2D72')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (358, 2, N'8DC86D0C28937FB+29C9')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (359, 0, N'8DC86D0C30D883E+26B0')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (359, 1, N'8DC86D0C3116D00+26B3')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (359, 2, N'8DC86D0C335D327+26B2')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (360, 0, N'8DC86D0C3957480+2300')
GO
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (361, 0, N'8DC86D0C3F2C1E6+1E23')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (362, 0, N'8DC86D0C4BBAE19+1868')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (363, 0, N'8DC86D0C51A3571+14B6')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (363, 1, N'8DC86D0C520B718+1606')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (363, 2, N'8DC86D0C5456AB7+1605')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (364, 0, N'8DC86D0C5C5F488+15DD')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (364, 1, N'8DC86D0C5CA5876+15AE')
INSERT [dbo].[ProductImages] ([productID], [displayIndex], [token]) VALUES (365, 0, N'8DC86D0C617ED57+2104')
GO
