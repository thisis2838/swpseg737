create database HLShop
-- Brands Table
INSERT INTO Brands (name, country, description) VALUES
('Acer', 'TW', 'Taiwanese multinational hardware and electronics corporation.'),
('Asus', 'TW', 'Taiwanese multinational computer and phone hardware and electronics company.'),
('HP', 'US', 'American multinational information technology company.'),
('Dell', 'US', 'American multinational computer technology company.'),
('Corsair',  'US', 'American computer peripheral and hardware company'),
('Logitech', 'CH', 'Swiss manufacturer of computer peripherals and software'),
('Intel', 'US', 'Intel Corp. is the worlds largest manufacturer of central processing units and semiconductors.'),
('AMD', 'US', 'AMD is a global semiconductor company known for its high-performance processors and graphics cards.'),
('NVIDIA', 'US', 'Nvidia is a prominent technology company recognized for its cutting-edge graphics processing units (GPUs) and artificial intelligence solutions.')
select * from Brands
-- Products Table
INSERT INTO Products (brandID, price, stock, name, description, isLaptop) VALUES
(1, 15250000, 20, 'ACER ASPIRE 7 A715-76-53PJ', 'Powerful laptop for everyday use.', 1),
(1, 18800000, 20, 'ACER SWIFT 3 SF314-512-56QN', 'Acer Swift 3 deserves to be one of the top choices for users in the study-office laptop segment with its compact, luxurious design and outstanding performance from its advanced AMD CPU.', 1),
(1, 9500000, 20, 'ACER ASPIRE 3 A315-510P-34XZ', 'Acer Aspire 3 deserves to be one of the top choices for users in the study-office laptop segment with its compact, luxurious design and outstanding performance from its advanced AMD CPU.', 1),
(2, 20350000, 20, 'ASUS VIVOBOOK A1505VA-L1491W', 'Powerful laptop for everyday use.', 1),
(2, 17199000, 20, 'ASUS GAMING TUF FX506HF-HN078W', 'High-performance gaming laptop.', 1),
(2, 26350000, 20, 'ASUS GAMING TUF FA507NV-LP046W', 'High-performance gaming laptop.', 1),
(3, 22350000, 20, 'HP PROBOOK 450 G10 (9H1N6PT)', 'Powerful laptop for everyday use', 1),
(3, 17000000, 20, 'HP Pavilion 15', 'Reliable laptop with a sleek design.', 1),
(3, 16500000, 20, 'HP 15-FD0081TU (8D734PA)', 'Powerful laptop for everyday use', 1),
(4, 18000000, 20, 'DELL VOSTRO 3430 (71021669)', 'Reliable laptop with a sleek design.', 1),
(4, 51499000, 20, 'Dell XPS 13', 'Compact, powerful ultrabook.', 1),
(4, 32000000, 20, 'DELL GAMING G15 5520 (71000334)', 'High-performance gaming laptop.', 1),
(5, 1700000, 20, 'Corsair K70 RGB TKL', 'Tenkeyless mechanical gaming keyboard with Cherry MX switches', 0),
(5, 1200000, 20, 'Corsair Harpoon RGB Pro', 'Wired optical gaming mouse with RGB lighting', 0),
(6, 2250000, 20, 'Logitech G Pro X Keyboard', 'Tenkeyless mechanical gaming keyboard with swappable switches', 0),
(6, 1000000, 20, 'Logitech G502 HERO', 'Wired gaming mouse with adjustable weights and RGB lighting', 0)
select * from Products
-- ProductImages Table
INSERT INTO ProductImages (productID, displayIndex, link) VALUES
(1, 1, 'https://hanoicomputercdn.com/media/product/76816_laptop_acer_aspire_7_a715_76_53pj__nh_qgesv_007___1_.jpg'),
(1, 2, 'https://hanoicomputercdn.com/media/product/76816_laptop_acer_aspire_7_a715_76_53pj__nh_qgesv_007___5_.jpg'),
(1, 3, 'https://hanoicomputercdn.com/media/product/76816_laptop_acer_aspire_7_a715_76_53pj__nh_qgesv_007___4_.jpg'),
(1, 4, 'https://hanoicomputercdn.com/media/product/76816_laptop_acer_aspire_7_a715_76_53pj__nh_qgesv_007___6_.jpg'),
(2, 1, 'https://hanoicomputercdn.com/media/product/67515_laptop_acer_swift_3_sf314_512_16.png'), 
(2, 2, 'https://hanoicomputercdn.com/media/product/67515_laptop_acer_swift_3_sf314_512_15.png'),
(2, 3, 'https://hanoicomputercdn.com/media/product/67515_laptop_acer_swift_3_sf314_512_14.png'),
(2, 4, 'https://hanoicomputercdn.com/media/product/67515_laptop_acer_swift_3_sf314_512_12.png'),
(3, 1, 'https://hanoicomputercdn.com/media/product/78990_laptop_acer_aspire_3_a315_510p_34xz__nx_kdhsv_006_.jpg'),
(3, 2, 'https://hanoicomputercdn.com/media/product/78990_laptop_acer_aspire_3_a315_510p_34xz__nx_kdhsv_006__1.jpg'),
(3, 3, 'https://hanoicomputercdn.com/media/product/78990_laptop_acer_aspire_3_a315_510p_34xz__nx_kdhsv_006__2.jpg'),
(3, 4, 'https://hanoicomputercdn.com/media/product/78990_laptop_acer_aspire_3_a315_510p_34xz__nx_kdhsv_006__4.jpg'),
(4, 1, 'https://hanoicomputercdn.com/media/product/81297_laptop_asus_vivobook_a1505va_l1491w___3_.jpg'),
(4, 2, 'https://hanoicomputercdn.com/media/product/81297_laptop_asus_vivobook_a1505va_l1491w___1_.jpg'),
(4, 3, 'https://hanoicomputercdn.com/media/product/81297_laptop_asus_vivobook_a1505va_l1491w___4_.jpg'),
(4, 4, 'https://hanoicomputercdn.com/media/product/81297_laptop_asus_vivobook_a1505va_l1491w___2_.jpg'),
(5, 1, 'https://hanoicomputercdn.com/media/product/79025_laptop_asus_gaming_tuf_fx506hf_hn078w__2_.jpg'),
(5, 2, 'https://hanoicomputercdn.com/media/product/79025_laptop_asus_gaming_tuf_fx506hf_hn078w__6_.jpg'),
(5, 3, 'https://hanoicomputercdn.com/media/product/79025_laptop_asus_gaming_tuf_fx506hf_hn078w__4_.jpg'),
(5, 4, 'https://hanoicomputercdn.com/media/product/79025_laptop_asus_gaming_tuf_fx506hf_hn078w__5_.jpg'),
(6, 1, 'https://hanoicomputercdn.com/media/product/72062_rtx40series_fa507nv_lp046w.png'), 
(6, 2, 'https://hanoicomputercdn.com/media/product/72062_laptop_asus_gaming_tuf_fa507nu_10.jpg'),
(6, 3, 'https://hanoicomputercdn.com/media/product/72062_laptop_asus_gaming_tuf_fa507nu_9.jpg'),
(6, 4, 'https://hanoicomputercdn.com/media/product/72062_laptop_asus_gaming_tuf_fa507nu_8.jpg'),
(7, 1, 'https://hanoicomputercdn.com/media/product/78900_laptop_hp_probook_450_g10__9h1n4pt___1_.jpg'),
(7, 2, 'https://hanoicomputercdn.com/media/product/78900_laptop_hp_probook_450_g10__9h1n4pt___2_.jpg'),
(7, 3, 'https://hanoicomputercdn.com/media/product/78900_laptop_hp_probook_450_g10__9h1n4pt___3_.jpg'),
(7, 4, 'https://hanoicomputercdn.com/media/product/78900_laptop_hp_probook_450_g10__9h1n4pt___4_.jpg'),
(8, 1, 'https://hanoicomputercdn.com/media/product/71901_laptop_hp_pavilion_x360_14_6.png'),
(8, 2, 'https://hanoicomputercdn.com/media/product/71901_laptop_hp_pavilion_x360_14_5.png'), 
(8, 3, 'https://hanoicomputercdn.com/media/product/71901_laptop_hp_pavilion_x360_14_4.png'),
(8, 4, 'https://hanoicomputercdn.com/media/product/71901_laptop_hp_pavilion_x360_14_3.png'),
(9, 1, 'https://hanoicomputercdn.com/media/product/76396_laptop_hp_15_fd0081tu___1_.jpg'),
(9, 2, 'https://hanoicomputercdn.com/media/product/76396_laptop_hp_15_fd0081tu___6_.jpg'),
(9, 3, 'https://hanoicomputercdn.com/media/product/76396_laptop_hp_15_fd0081tu___5_.jpg'),
(9, 4, 'https://hanoicomputercdn.com/media/product/76396_laptop_hp_15_fd0081tu___2_.jpg'),
(10, 1, 'https://hanoicomputercdn.com/media/product/76262_laptop_dell_vostro_3430__71015715_.jpg'),
(10, 2, 'https://hanoicomputercdn.com/media/product/76261_laptop_dell_vostro_3430__71015716_.jpg'),
(10, 3, 'https://hanoicomputercdn.com/media/product/76261_laptop_dell_vostro_3430__71015716_.jpg'),
(10, 4, 'https://hanoicomputercdn.com/media/product/76262_laptop_dell_vostro_3430__71015717_.jpg'),
(11, 1, 'https://hanoicomputercdn.com/media/product/82352_laptop_dell_xps_13_9340__71034923_.jpg'),
(11, 2, 'https://hanoicomputercdn.com/media/product/82352_laptop_dell_xps_13_9340__71034927_.jpg'),
(11, 3, 'https://hanoicomputercdn.com/media/product/82352_laptop_dell_xps_13_9340__71034926_.jpg'),
(11, 4, 'https://hanoicomputercdn.com/media/product/82352_laptop_dell_xps_13_9340__71034925_.jpg'),
(12, 1, 'https://hanoicomputercdn.com/media/product/69038_laptop_dell_gaming_g15_5525_11.png'),
(12, 2, 'https://hanoicomputercdn.com/media/product/69038_laptop_dell_gaming_g15_5525_10.png'),
(12, 3, 'https://hanoicomputercdn.com/media/product/69038_laptop_dell_gaming_g15_5525_10.png'),
(12, 4, 'https://hanoicomputercdn.com/media/product/69038_laptop_dell_gaming_g15_5525_6.png'),
(13, 1, 'https://hanoicomputercdn.com/media/product/58637_ban_phim_corsair_k70_tkl_rgb_champion_usb_speed_sw_0001_2.jpg'),
(13, 2, 'https://hanoicomputercdn.com/media/product/58637_ban_phim_corsair_k70_tkl_rgb_champion_usb_speed_sw_0003_4.jpg'),
(13, 3, 'https://hanoicomputercdn.com/media/product/58637_ban_phim_corsair_k70_tkl_rgb_champion_usb_speed_sw_0000_1.jpg'),
(14, 1, 'https://hanoicomputercdn.com/media/product/48439_chuot_corsair_harpoon_rgb_pro_ch_9301111ap_0002_1.jpg'),
(14, 2, 'https://hanoicomputercdn.com/media/product/48439_chuot_corsair_harpoon_rgb_pro_ch_9301111ap_0001_3.jpg'),
(14, 3, 'https://hanoicomputercdn.com/media/product/48439_chuot_corsair_harpoon_rgb_pro_ch_9301111ap_0003_2.jpg'),
(15, 1, 'https://hanoicomputercdn.com/media/product/49500_ban_phim_co_logitech_g_pro_x_rgb_lightsync_mechanical_gx_blue_switch_gaming_keyboard_0001_1.jpg'),
(15, 2, 'https://hanoicomputercdn.com/media/product/49500_ban_phim_co_logitech_g_pro_x_rgb_lightsync_mechanical_gx_blue_switch_gaming_keyboard_0002_2.jpg'),
(16, 1, 'https://hanoicomputercdn.com/media/product/44370_mouse_logitech_g502_hero_gaming_usb_black_0003_1.jpg'),
(16, 2, 'https://hanoicomputercdn.com/media/product/44370_mouse_logitech_g502_hero_gaming_usb_black_0001_3.jpg'),
(16, 3, 'https://hanoicomputercdn.com/media/product/44370_kich_thuoc_mouse_logitech_g502_hero_gaming_usb_black.jpg')

-- LaptopCPUSeries Table
INSERT INTO LaptopCPUSeries (name, description, manufacturerID) VALUES
('Intel Core i5', 'Mid-range performance CPU.', 7),
('Intel Core i7', 'High-performance CPU.', 7),
('AMD Ryzen 7', 'Efficient multi-core CPU.', 8)

-- LaptopGPUSeries Table
INSERT INTO LaptopGPUSeries (name, description, manufacturerID) VALUES
('NVIDIA GeForce RTX 20XX', 'Mid-range gaming GPU.', 9),
('NVIDIA GeForce RTX 40XX', 'High-level Gaming GPU', 9),
('NVIDIA GeForce RTX 30XX', 'Mid-range gaming GPU', 9),
('Intel Iris Xe Graphics', 'Integrated graphics for lightweight tasks.', 7)

-- Laptops Table
INSERT INTO Laptops (productID, cpuSeries, gpuSeries, screenSize, screenResolution, screenAspectRatio, storageType, storageSize, refreshRate, ram) VALUES
(1, 1, 4, 15, '1920x1080', '16:9', 1, 512, 60, 8),
(2, 2, 4, 14, '2560x1440', '16:9', 1, 512, 120, 16),
(3, 1, 4, 15, '1920x1080', '16:9', 0, 1024, 60, 8),
(4, 2, 4, 14, '1920x1280', '16:9', 1, 512, 60, 16),
(5, 1, 1, 15, '1920x1080', '16:10', 1, 512, 144, 16),
(6, 3, 2, 15, '1920x1080', '16:9', 1, 512, 144, 16),
(7, 2, 4, 15, '1920x1080', '16:10', 1, 512, 60, 8),
(8, 1, 4, 15, '1920x1080', '16:10', 1, 512, 60, 16),
(9, 1, 4, 15, '1920x1080', '16:9', 1, 512, 60, 8),
(10, 1, 4, 14, '2560x1440', '16:10', 0, 512, 60, 16),
(11, 2, 4, 13, '2560x1440', '16:9', 1, 1024, 120, 16),
(12, 2, 3, 15, '2560x1440', '16:9', 0, 512, 165, 16)
