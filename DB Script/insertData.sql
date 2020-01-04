-- `dbo.AspNetRoles`
INSERT dbo.AspNetRoles VALUES (N'1', N'Admin') -- 系統管理者
INSERT dbo.AspNetRoles VALUES (N'3', N'Test')
INSERT dbo.AspNetRoles VALUES (N'2', N'User') -- 一般使用者

-- `dbo.AspNetUsers`
-- 預設登入密碼是123456
INSERT dbo.AspNetUsers VALUES (N'67677e28-8f75-4523-900a-f11f8d7608e5', N'test@test.com', 0, N'ABToTwONjTRWb8ZrO9b7frF65YkKGRfH3REpfXs/pnheAweLa6fvwhzB49+Oq2/b+Q==', N'd4ca5b7a-b029-4258-883c-1d1e307b04a9', NULL, 0, 0, NULL, 0, 0, N'test@test.com')

-- `dbo.AspNetUserRoles`
-- 預設角色是Admin
INSERT dbo.AspNetUserRoles VALUES (N'67677e28-8f75-4523-900a-f11f8d7608e5', N'1')
