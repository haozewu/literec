# SREC

[![version](https://img.shields.io/badge/version-1.0.0.20201120-blue.svg?style=flat-square)](https://srec-1251216093.file.myqcloud.com/SREC.zip)
[![license](https://img.shields.io/github/license/Ouyang-Zhaoxing/SREC.svg?style=flat-square)](https://github.com/Ouyang-Zhaoxing/SREC/blob/master/LICENSE)

轻量级的绿色便携屏幕录制、直播工具。

## **如何使用**
点击上方 **version** 标签下载 点击**录制**或使用快捷键【Ctrl+F11】启动录制 【Ctrl+F12】停止录制

## **编码器**
目前支持CPU、英特尔QSV和英伟达NVENC三种编码器。

默认为CPU编码，个别设备可能会出现录制内容绿屏花屏等问题，请切换到其他编码器。


## **FAQ**

**为什么我使用 QSV/NVENC 硬件编码器时无效？**

使用硬件编码器无效时，请更新对应的显卡驱动或前往官网查看设备是否支持。双显卡笔记本，建议采用QSV编码器。

**为什么我无法录制系统声音？**

程序默认功能只捕获屏幕，录制系统声音需要第三方插件支持，请安装插件 **Screen Capture Recorder**（已集成 **Virtual Audio Capture** ）

**安装插件时需要管理员权限，我希望知道程序对我的计算机做了哪些更改，或者我是否可以手动注册插件？**

手动注册和卸载插件方法：

注册：`regsvr32 DLLPath` 卸载：`regsvr32 /u DLLPath`

程序做了一样的事情。


## **开发**
- 建议使用 [Visual Studio 2019](https://visualstudio.microsoft.com/) 或更高版本
- .NET Framework 4.6


## **许可证**
[MIT License](https://github.com/Yiwei-Brunhlio/SREC/blob/master/LICENSE)
