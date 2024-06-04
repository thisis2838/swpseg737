CREATE TABLE Users
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    name
        NVARCHAR(MAX)
        NOT NULL,
    email
        NVARCHAR(MAX)
        NOT NULL,
    passHash
        CHAR(32)
        NULL,
    gender
        BIT
        NOT NULL,
    phoneNumber
        VARCHAR(20)
        NOT NULL,
    customerTier
        TINYINT
        NOT NULL,
    isSales
        BIT
        NOT NULL,
    isMarketing
        BIT
        NOT NULL,
    isAdmin
        BIT
        NOT NULL
);
GO

CREATE TABLE Brands
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    name
        NVARCHAR(MAX)
        NOT NULL,
    description
        NVARCHAR(MAX)
        NULL,
    country
        NVARCHAR(255)
        NOT NULL    
);
CREATE TABLE Products
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    brandID
        INTEGER
        FOREIGN KEY REFERENCES Brands(id),
    name
        NVARCHAR(MAX)
        NOT NULL,
    price
        INTEGER
        NOT NULL,
    stock
        INTEGER
        NOT NULL,
    description
        NVARCHAR(MAX)
        NULL,
    isLaptop
        BIT
        NOT NULL
);
CREATE TABLE ProductImages
(
    productID
        INTEGER
        FOREIGN KEY REFERENCES Products(id),
    displayIndex
        INTEGER
        NOT NULL,
    token
        VARCHAR(MAX)
        NOT NULL,

    PRIMARY KEY (productID, displayIndex)
);
GO

CREATE TABLE LaptopCPUSeries
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    name
        NVARCHAR(MAX)
        NOT NULL,
    description
        NVARCHAR(MAX)
        NULL,
    manufacturerID
        INTEGER
        FOREIGN KEY REFERENCES Brands(id)
);
CREATE TABLE LaptopGPUSeries
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    name
        NVARCHAR(MAX)
        NOT NULL,
    description
        NVARCHAR(MAX)
        NULL,
    manufacturerID
        INTEGER
        FOREIGN KEY REFERENCES Brands(id)
);
CREATE TABLE Laptops
(
    productID
        INTEGER
        PRIMARY KEY
        FOREIGN KEY REFERENCES Products(id),
    cpuSeries
        INTEGER
        FOREIGN KEY REFERENCES LaptopCPUSeries(id),
    gpuSeries
        INTEGER
        FOREIGN KEY REFERENCES LaptopGPUSeries(id),
    screenSize
        REAL
        NOT NULL,
    screenResolution
        VARCHAR(20)
        NOT NULL,
    screenAspectRatio
        VARCHAR(20)
        NOT NULL,
    storageType
        TINYINT
        NOT NULL,
    storageSize
        INTEGER
        NOT NULL,
    refreshRate
        INTEGER
        NOT NULL,
    ram
        INTEGER
        NOT NULL
);
GO

CREATE TABLE Vouchers 
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    code
        VARCHAR(20)
        NOT NULL,
    minimumOrderPrice
        REAL
        NOT NULL,
    discountValue
        REAL
        NOT NULL,
    isPercentageDiscount
        BIT
        NOT NULL,
    expiryDate
        DATE
        NOT NULL,
    issuerID
        INTEGER
        FOREIGN KEY REFERENCES Users(id)
);
CREATE TABLE Orders
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    buyerID
        INTEGER 
        FOREIGN KEY REFERENCES Users(id),
    status
        TINYINT
        NOT NULL,
    address
        NVARCHAR(MAX)
        NOT NULL,
    phoneNumber
        VARCHAR(20)
        NOT NULL,
    note
        NVARCHAR(MAX)
        NULL,
    creationTime
        DATETIME
        NOT NULL,
    totalPrice
        REAL
        NOT NULL,
    paymentMethod
        TINYINT
        NOT NULL,
    voucherID
        INTEGER
        FOREIGN KEY REFERENCES Vouchers(id)
);
CREATE TABLE OrderDetails
(
    orderID
        INTEGER
        FOREIGN KEY REFERENCES Orders(id),
    productID
        INTEGER
        FOREIGN KEY REFERENCES Products(id),
    amount
        INTEGER
        NOT NULL,

    PRIMARY KEY (orderID, productID)
);
GO

CREATE TABLE ProductReviews
(
    productID
        INTEGER
        FOREIGN KEY REFERENCES Products(id),
    reviewerID
        INTEGER
        FOREIGN KEY REFERENCES Users(id),
    rating
        INTEGER
        NOT NULL,
    content
        NVARCHAR(MAX)
        NOT NULL,
    time
	DATETIME
	NOT NULL

    PRIMARY KEY (productID, reviewerID)
);
CREATE TABLE NewsPosts
(
    id
        INTEGER
        IDENTITY(1,1)
        PRIMARY KEY,
    time
        DATETIME
        NOT NULL,
    title
        NVARCHAR(MAX)
        NOT NULL,
    content
        NVARCHAR(MAX)
        NOT NULL,
    authorID
        INTEGER
        FOREIGN KEY REFERENCES Users(id)
);
GO

select * from Laptops