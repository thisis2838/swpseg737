
CREATE TRIGGER trg_InsertReview
ON [ProductReviews]
AFTER INSERT
AS
BEGIN
    UPDATE [Products]
    SET 
        reviewCount = reviewCount + 1,
        reviewTotal = reviewTotal + inserted.rating
    FROM 
        products
    INNER JOIN 
        inserted ON [Products].id = [inserted].productID;
END;
GO

CREATE TRIGGER trg_DeleteReview
ON [ProductReviews]
AFTER DELETE
AS
BEGIN
    UPDATE [Products]
    SET 
        reviewCount = reviewCount - 1,
        reviewTotal = reviewTotal - deleted.rating
    FROM 
        products
    INNER JOIN 
        deleted ON [Products].id = deleted.productID
END;
GO

CREATE TRIGGER trg_UpdateReview
ON [ProductReviews]
AFTER UPDATE
AS
BEGIN
    UPDATE [Products]
    SET 
        reviewTotal = reviewTotal - deleted.rating + inserted.rating
    FROM 
        products
    INNER JOIN 
        inserted ON [Products].id = inserted.productID
    INNER JOIN 
        deleted ON [Products].id = deleted.productID;
END;
GO