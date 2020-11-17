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
ngx.print(
    "{" ..'"userBio"' .. ":" .. res1.body .. "," .. '"userPost"' .. ":" .. res2.body .. "}"
)