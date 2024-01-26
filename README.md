<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/hjt486/ChinesePassportPhotoMaker">
    <img src="graphics/icon.png" alt="Logo" width="128" height="128">
  </a>

  <h4><b> 已停止更新！</b></h4>
  请移步去最新跨平台网页版：<a href="https://github.com/hjt486/passport-photo-maker"><strong>{ 点击查看 }</strong></a>

  <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

<h3 align="center">中国护照照片生成器</h3>

  <p align="center">
    不需要任何图像处理知识，只需要简单的动动鼠标，就可以快速生成符合标准的中国护照照片。
    <br />
    <strong>注：目前仅支持运行在Windows平台。</strong>
    <br />
    <br />
    <a href="https://www.youtube.com/watch?v=Q86svYysahA"><strong>{ 点击查看视频教程 }</strong></a>
    <!--
    <br />
    <a href="https://github.com/github_username/repo_name"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/github_username/repo_name">View Demo</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Report Bug</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Request Feature</a>
	-->
  </p>

</div>


<!-- ABOUT THE PROJECT -->
## 简介
<div align="center">
    <a href="https://github.com/hjt486/ChinesePassportPhotoMaker">
        <img src="graphics/screenshot.png" alt="程序界面预览" width="400"">
    </a>
</div>

疫情开始以来，世界各地的中国使领馆均改变了对外办公的时间和方式，使得护照到期换发变的更加麻烦。以前经常有朋友抱怨使领馆对于照片的要求过于苛刻，很多通过第三方拍摄的照片都无法通过验证，但是疫情前的使领馆内部或附近都有相应的自助照片拍摄机器，或者了解相关标准的第三方摄影馆，除了额外的费用和一定的时间成本，绝大多数的情况下并不会耽误护照换发申请流程。如今因为很多使领馆不对外开放，同时引入了领事服务App，因此申请人需要在申请前期就要上传符合标准的照片，即便照片通过了初步验证，如果不符合具体要求，依然可能在后期审核过程中被拒绝，极大程度上增加了不确定性和时间成本。实际上，中国外交部领事服务网上发布的关于护照照片的标准非常清晰和详细，对于照片上人像的各种距离、大小均有明确的规定，但是对于绝大多数人，这些枯燥和详细的数字只是增加了理解的难度，同时因为缺乏处理照片的相关知识，使得很多人感觉无从下手又不知道去哪里寻求帮助。这个程序的存在，就是为了帮助大家化繁为简，用清晰明了的可视化的方式快速生成符合标准的照片。

<p align="right">(<a href="#top">回到页首</a>)</p>

### Built With

* Visual Studio 2019
* .NET Core 3.1
* WPF

<p align="right">(<a href="#top">回到页首</a>)</p>

### 已知问题

* 图片移动过程中偶尔图片位置会跳跃（鼠标坐标计算bug？）；

* Microsoft的Jpeg Encoder产生的图片质量在相同大小下非常差（换成其他开源Encoder？）；

* 打开，关闭 “显示实例” 后，已载入的图片位置会改变（坐标计算bug？）；

<p align="right">(<a href="#top">回到页首</a>)</p>



### 待添加功能

* 产生2排4列4‘’x6''规格300DPI格式高质量（PNG?）照片，分成两张照片一组（3组），分别添加一定程度的尺寸缩放浮动，防止打印过程中被缩放，保证至少一组（两张）符合尺寸要求；
* 遥远的未来：简单的亮度，对比度，饱和度，色阶等进阶图像调整功能；
* 遥远的未来：macOS，iOS和Android版本；
* 极端遥远的未来：AI边缘检测，自动对齐和自动图像调整甚至脸部球面修正；
* （欢迎在讨论区留言建议，或者其他开发者建立新的Branch来添加新功能）。

<p align="right">(<a href="#top">回到页首</a>)</p>

<div>
<!--
<!-- GETTING STARTED -->
