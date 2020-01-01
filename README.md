# CloudmusicPlayList2CSV
## 网易云歌单转CSV

使用这个工具能够将您的网易云歌单内容保存为CSV文件。

### 如何使用?

1、登录网易云音乐网页端 music.163.com

2、F12打开开发者工具，选择网络(Network)，选择过滤器XHR

3、在网易云音乐网页端中进入“我的音乐”，并打开需要操作的歌单

4、选中开发者工具中捕获到名为"detail?csrf_token=xxxx"的请求，右键-"copy"-"Copy response"

5、将复制的请求粘贴到文本文件中保存（注意保存编码为UTF-8）

6、打开CloudmusicPlayList2CSV工具，提示输入json文件路径，将上一步保存的文本文件拖入窗口即可自动填写路径。

7、Enter，如果没有错误发生，即转换成功。
