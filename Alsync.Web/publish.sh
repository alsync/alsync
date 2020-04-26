# 复制Dockerfile文件到项目根目录。
cp -r ./Alsync.Web/Dockerfile ./

# 将映像命名为 alsync.web。
# 在当前文件夹（末尾的句点）中查找 Dockerfile。
docker build -t alsync.web .

# -rm容器在退出时自动删除
docker run -it --rm --name alsync.web alsync.web