-- 启用UUID
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- 创建表（如果尚不存在） 用户信息表
CREATE TABLE IF NOT EXISTS "user"
(
    "uuid"          UUID PRIMARY KEY                  DEFAULT uuid_generate_v4(), -- UUID
    "database_id"  INT                      NOT NULL,                            -- 用户库ID
    "uid"           VARCHAR(255)             NOT NULL UNIQUE,                     -- UID
    "name"          VARCHAR(255)             NOT NULL UNIQUE,                     -- 用户名
    "password"      VARCHAR(255)             NOT NULL,                            -- 密码
    "salt"          BYTEA                    NOT NULL,                            -- 密码盐
    "email"         VARCHAR(255) UNIQUE,                                          -- 电子邮箱
    "phone"         VARCHAR(255) UNIQUE,                                          -- 手机号
    "email_state"   INT                      NOT NULL DEFAULT 0,                  -- 电子邮箱状态
    "phone_state"   INT                      NOT NULL DEFAULT 0,                  -- 手机号状态
    "state"         INT                      NOT NULL DEFAULT 0,                  -- 账号状态
    "type"          INT                      NOT NULL DEFAULT 0,                  -- 用户类型
    "current_ip"    VARCHAR(255),                                                 -- 当前IP
    "register_time" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP   -- 注册时间
);
