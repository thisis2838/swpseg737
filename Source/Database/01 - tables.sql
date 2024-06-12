/*
    NOTES:

    very short text:        max 20 chars
    short text:             max 256 chars
    medium text:            max 1024 chars
    long text:              max 4000 chars
*/

CREATE TABLE Users
(
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    
    -- identity
    name                    NVARCHAR(256)   NOT NULL,
    email                   NVARCHAR(256)   NOT NULL,
    passHash                VARCHAR(256)    NULL,
    gender                  BIT             NOT NULL,
    phoneNumber             VARCHAR(20)     NOT NULL,
    -- roles/status
    isSales                 BIT             NOT NULL,
    isMarketing             BIT             NOT NULL,
    isAdmin                 BIT             NOT NULL,
    isDeleted               BIT             NOT NULL
);  
GO  
    
CREATE TABLE Brands 
(   
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    
    name                    NVARCHAR(256)   NOT NULL,
    description             NVARCHAR(1024)  NULL,
    country                 NVARCHAR(256)   NOT NULL    
);
CREATE TABLE Products
(
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    brandID                 INTEGER         NOT NULL FOREIGN KEY REFERENCES Brands(id),
    
    name                    NVARCHAR(256)   NOT NULL,
    price                   INTEGER         NOT NULL,
    stock                   INTEGER         NOT NULL,
    description             NVARCHAR(4000)  NULL,
    isDeleted               BIT             NOT NULL,
    isLaptop                BIT             NOT NULL    
);
CREATE TABLE ProductImages
(
    productID               INTEGER         FOREIGN KEY REFERENCES Products(id),
    displayIndex            INTEGER         NOT NULL,
    token                   VARCHAR(256)    NOT NULL,
    
    PRIMARY KEY (productID, displayIndex)
);
GO

CREATE TABLE LaptopCPUSeries
(
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    manufacturerID          INTEGER         NOT NULL FOREIGN KEY REFERENCES Brands(id),
    
    name                    NVARCHAR(256)   NOT NULL
);
CREATE TABLE LaptopGPUSeries
(
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    manufacturerID          INTEGER         NOT NULL FOREIGN KEY REFERENCES Brands(id),
    
    name                    NVARCHAR(256)   NOT NULL
);  
CREATE TABLE Laptops    
(   
    productID               INTEGER         PRIMARY KEY FOREIGN KEY REFERENCES Products(id),
    cpuSeries               INTEGER         NOT NULL FOREIGN KEY REFERENCES LaptopCPUSeries(id),
    gpuSeries               INTEGER         NULL FOREIGN KEY REFERENCES LaptopGPUSeries(id),
    
    -- screen
    screenSize              REAL            NOT NULL,
    screenResolution        VARCHAR(20)     NOT NULL,
    screenAspectRatio       VARCHAR(20)     NOT NULL,
    --storage
    storageType             TINYINT         NOT NULL,
    storageSize             INTEGER         NOT NULL,
    -- etc
    refreshRate             INTEGER         NOT NULL,
    ram                     INTEGER         NOT NULL
);  
GO  
    
CREATE TABLE Vouchers   
(   
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    issuerID                INTEGER         NOT NULL FOREIGN KEY REFERENCES Users(id),
    
    code                    VARCHAR(20)     NOT NULL,
    minimumOrderPrice       MONEY           NOT NULL,
    discountValue           MONEY           NOT NULL,
    isPercentageDiscount    BIT             NOT NULL,
    expiryDate              DATE            NOT NULL,
    isDeleted               BIT             NOT NULL
);
CREATE TABLE Orders
(
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    buyerID                 INTEGER         NOT NULL FOREIGN KEY REFERENCES Users(id),
    
    status                  TINYINT         NOT NULL,
    orderTime               DATETIME        NOT NULL,
    -- destination    
    province                NVARCHAR(256)   NOT NULL,  
    district                NVARCHAR(256)   NOT NULL,    
    ward                    NVARCHAR(256)   NOT NULL,    
    street                  NVARCHAR(256)   NOT NULL,
    recipientName           NVARCHAR(256)   NOT NULL,
    phoneNumber             VARCHAR(20)     NOT NULL,
    note                    NVARCHAR(1024)  NULL,
    -- money
    totalPrice              MONEY           NOT NULL,
    discountedPrice         MONEY           NOT NULL,
    paymentMethod           TINYINT         NOT NULL,
    voucherID               INTEGER         NULL FOREIGN KEY REFERENCES Vouchers(id)
);
CREATE TABLE OrderDetails
(
    orderID                 INTEGER         FOREIGN KEY REFERENCES Orders(id),
    productID               INTEGER         FOREIGN KEY REFERENCES Products(id),   
    
    quantity                INTEGER         NOT NULL,
    productPrice            INTEGER         NOT NULL, 
    subTotal                AS productPrice * quantity, 
    
    PRIMARY KEY (orderID, productID)
);
GO

CREATE TABLE ProductReviews
(
    productID               INTEGER         FOREIGN KEY REFERENCES Products(id),
    reviewerID              INTEGER         FOREIGN KEY REFERENCES Users(id),
    
    reviewTime              DATETIME        NOT NULL,
    rating                  INTEGER         NOT NULL,
    content                 NVARCHAR(1024)  NOT NULL

    PRIMARY KEY (productID, reviewerID)
);
CREATE TABLE NewsPosts
(
    id                      INTEGER         IDENTITY(1,1) PRIMARY KEY,
    authorID                INTEGER         NOT NULL FOREIGN KEY REFERENCES Users(id),
    
    postTime                DATETIME        NOT NULL,
    title                   NVARCHAR(256)   NOT NULL,
    token                   VARCHAR(256)    NOT NULL
);
GO