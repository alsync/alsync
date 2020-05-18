# 复制Dockerfile文件到项目根目录。
cp -r ./Alsync.Web/Dockerfile ./

# 创建镜像并命名为 alsync.web。
# 在当前文件夹（末尾的句点.）中查找 Dockerfile。
docker build -t alsync.web .

# 运行容器
# --name alsync.web 容器命名为alsync.web
# -rm 容器在退出时自动删除
# -d 后台运行
# -p 5000:80 将本地计算机上的端口 5000 映射到容器中的端口 80
docker run -it --rm -p 5000:80 --name alsync.web alsync.web