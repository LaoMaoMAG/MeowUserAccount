-- 创建表（如果尚不存在） 用户库配置表
CREATE TABLE IF NOT EXISTS "user_warehouse"
(
    id               INT GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,           -- 索引ID
    "name"           VARCHAR(255)             NOT NULL UNIQUE,                   -- 用户名
    "start"          INT                      NOT NULL DEFAULT 0,                -- 状态
    "open_login"     INT                      NOT NULL DEFAULT 0,                -- 开放登录
    "open_register"  INT                      NOT NULL DEFAULT 0,                -- 开放注册
    "register_email" INT                      NOT NULL DEFAULT 0,                -- 注册邮箱
    "register_phone" INT                      NOT NULL DEFAULT 0,                -- 注册手机号
    "email_verify"   INT                      NOT NULL DEFAULT 0,                -- 邮箱验证
    "phone_verify"   INT                      NOT NULL DEFAULT 0,                -- 手机号验证
    "notes"          TEXT,                                                       -- 备注
    "create_time"    TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP -- 创建时间
);
