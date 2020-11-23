-- the main portion that calls both the services and stores the response in
-- two variables
local uri = ngx.var.request_uri
local userId = string.match(uri, '[^/]*$')
local res1,res2 = ngx.location.capture_multi{
    {"/user-api/v1/userbios/" .. userId},
    {"/post-api/v1/userposts/user/" .. userId}
}
--  content type header
ngx.header.content_type = "application/json; charset=utf-8"

local function isempty(s)
    return s == nil or s == ''
end

local bio;
local posts;

if isempty(res1.body) then
    bio = "{}"
else
    bio = res1.body
end

if isempty(res2.body) then
    posts = "[]"
else
    posts = res2.body
end

ngx.print(
    "{" ..'"userBio"' .. ":" .. bio .. "," .. '"userPost"' .. ":" .. posts .. "}"
)