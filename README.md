# 2022年毕业设计

> 设计题目：虚拟仿真游戏的设计与实现  
>
> 使用技术：Unity3D  
>
> 制作目的：完成毕业论文
>
> 制作人：张程瑞  
>
> 简介：此项目为2022年大连东软信息学院 高等职业技术学院 虚拟现实19101班 张程瑞 的毕业设计，主要设计为虚拟现实游戏，主要技术为Unity3D。

[TOC]

## 摘要  

虚拟现实技术，在1963年以前就被提出，而到了21世纪的今天，我们依旧对这项技术充满了争议，不过在近几年的科技发展中，随着计算设备算力越发的提高，“云计算”等技术的逐渐兴起，让虚拟现实这一承载着人类无数想象力的技术再度出现在了大众的视野中。伴随着虚拟现实技术的发展越发的完善，这项技术也走进了我们普通人的生活中。  
在日常生活中，我们不可避免的通过网购平台购买一些商品，而在购买的过程中，作为消费者的我们不能真正的全方位的看见商品实物，也没办法直观的了解到商品的信息，作为商家，也没有更好的手段让消费者看到自己的商品实物，所以设计一款面向全体消费者与全体商家的，能帮助消费者简单、直观的看到商品样式，帮助商家向消费者展示商品的应用——《虚拟仿真游戏》。《虚拟仿真游戏》分为面向客户的客户端，面向管理员的管理端，与面向运维人员的服务端。本人将负责这三端的实现与统一整合。  
在本项目的设计与实践过程中，采用Unity3D游戏引擎、C#程序语言与服务器程序进行数据的接收、发送及保存，使用Photoshop图像处理工具、3ds Max建模渲染工具等进行客户端与管理端的设计与开发，通过ASP.NET Core技术配合Docker容器完成服务器端的构建与部署。  
最终面向全体消费者与全体商家的《虚拟仿真游戏》客户端与管理端可以运行于Windows、Linux、Android等设备中，方便用户和管理员通过各种设备使用程序。《虚拟仿真游戏》服务端运行于通过Docker容器实现的服务器虚拟容器中，方便服务器运维人员为服务端进行部署与运维。  
经过多次测试，该应用功能简洁实用，界面友好美观，软件运行稳定，并具有良好的操作可行性和技术可行性，用户体验良好。  

关键词：虚拟现实，Unity3D，C#，ASP.NET Core  

## 第1章 绪论

### 论文研究背景

虚拟现实技术承载了人类对未来科技的无限幻想，而未曾发现，其实这项技术早已围绕在我们生活中的方方面面。购物是现代人必不可少的一种休闲活动，而在购物过程中，用户总会懊恼一件事情，那就是如何能在商品到手之前看到商品的全貌，如何能更加直观了解到商品的详细信息。售卖商品的商家也会懊恼，如何能让自己的商品更加吸引客户，如何能让用户更加深刻的了解到商品的信息。  
因此，设计一款能够让商家和客户都可以满意的解决方案便是至关重要的一件事，众所周知，能够更加直观地查看商品样式的方式，就是使用虚拟现实技术将商品进行3D建模后，通过3D仿真的形式，被管理者上传到云端，用户通过自己手中的客户端，或者在商场中的嵌入式设备中运行客户端程序，从而快速的让用户看到商品的实物及其信息，让商家也可以不必纠结如何展示自己的商品而苦恼。  
因此设计了一个满足用户购物过程中能更加清晰明了的看到产品，管理者能更加方便的向用户展示产品细节的一整套解决方法。  

### 论文研究的目的及意义

让商家和用户同时满意，是一件很难达成的目标，对于这一点而言，关键的是在于，如何能让管理者更加轻松地使用该解决方案，使用户更加方便的从中预览到自己想了解的东西。  
原先市面上存在的各种解决方案，无一例外的，使用的技术都是web应用作为出发原点，产品面向的人群，要么是从商家的角度入手，去解决如何让用户更加精准地被推送到他喜欢的商品，要么是从用户的角度出发，以牺牲商家便利性为代价，让用户更加全面的去了解商品的全貌，但这两种解决方案都或多或少地存在着问题。单从一类群体出发，是无法解决上述问题的。  
而本项目，所采用的技术，为新兴的虚拟仿真技术，通过使用游戏引擎优秀的物理模拟，以及模型质感还原能力，让用户可以更加方便的了解到商品的样式以及商品的信息，并且通过游戏引擎健全的热更新生态，赋予了商家与管理者更加简单、方便、自由、快捷的3D模型模拟仿真分发渠道。  
通过这些技术，可以大幅度减少用户以及商家的使用门槛。并且通过封装好的工具，让管理者可以快速地根据季节、时段、活动来向用户分发不同的虚拟仿真模型，并通过一套完善的用户权限管理系统，使不同的终端设备，以及用户，能够接收到最适合的商品推送。得益于Unity 3D的跨平台能力，可以让用户端和管理端，兼容不同的操作系统，以及运行环境，使程序可以在用户自身的手持移动设备上，或者是商场中的嵌入式设备中流畅运行。  

### 论文研究主要内容

本文设计和实现了一款，针对于全体客户和全体商家的，能帮助快速、直观展示商品样式与特点的解决方案《虚拟仿真游戏》。本解决方案分为面向客户的客户端，面向管理者的管理端，面向运维人员的服务器端，本人负责这三端的实现与统一整合。该项目包括一套完整的Web API后端程序、客户端管理端统一的应用程序、经过封装后的解决方案制作工具。并且该项目通过热更新的方式实现，管理员上传成功模型后，客户端无需更新即可实时显示的优秀使用体验。并通过一套完整的用户权限管理以及模型权限分配框架，让不同用户组的用户可以接收到不同的模型，方便项目在线下实体店展示时，能够根据不同地点的需要，快速更换不同的模型进行显示。  
该项目的界面设计简单明了，方便管理员和用户使用该软件。项目采用了前后端分离的解耦合式设计，大幅度地减少了运维人员对服务器后端进行维护的难度。  
本项目基于Unity 3D开发平台，在设计之初使用了3ds Max3D建模软件、Photo Shop图像处理工具等一系列软件完成了用户端与管理端的实现。并通过ASP.NET Core技术、Docker容器等技术，完成了服务端的实现。  

### 国内外研究现状

随着虚拟实验技术的成熟，人们开始认识到虚拟仿真实验室在教育领域的应用价值，它除了可以辅助高校的科研工作，在实验教学方面也具有如利用率高易维护等诸多优点。近年来，国内的许多高校都根据自身科研和教学的需求建立了一些虚拟实验室。  
目前国内外都对虚拟实验平台进行了各种实质性的探索，各种虚拟平台层出不穷。对虚拟平台的运用大致有以下几个方面:城市规划、房地产行业、娱乐、艺术与教育。但是目前虚拟平台运用到教学中的平台在国内还相对较少，处于萌芽阶段，而国外已经有很多大学进行了这方面的研究。  

## 第2章 关键技术介绍

### Unity3D

Unity3D，是Unity Technologies 公司开发的三维游戏制作引擎，此引擎可将游戏发布至Windows、Mac、Wii、iPhone、WebGL（需要 HTML5）和 Android 平台，也可以利用 Unity Web Player 插件发布网页游戏，支持 Mac 和 Windows 平台的网页浏览，是一个全面整合的专业游戏引擎。通过该引擎，开发者可以轻松实现例如三维游戏，建筑可视化，实时三维动画等类型的互动内容。Unity官方配置了详细的用户使用手册，以及API文档供给开发者使用，并有着优秀的论坛资源，可以让开发者更加轻松地开发游戏，大幅度提高了工作效率。  

### ASP.NET Core

ASP.NET Core，是微软公司开发的一款跨平台的高性能开源框架，用于生成启用云且连接 Internet 的新式应用。使用 ASP.NET Core，可以生成 Web 应用和服务、物联网 (IoT) 应用和移动后端，在 Windows、macOS 和 Linux 上使用喜爱的开发工具，部署到云或本地，在 .NET Core 上运行。  
ASP.NET Core具有生成 Web UI 和 Web API 的统一场景，针对可测试性进行构建，Pages 可以使基于页面的编码方式更简单高效，共享全部使用 .NET 编写的服务器端和客户端应用逻辑，能够在 Windows、macOS 和 Linux 上进行开发和运行。开放源代码和以社区为中心，等优点。  
微软公司提供了详细的API文档供开发者使用，并具有良好的用户支持以及程序稳定性。  

### Adobe Photoshop

Adobe Photoshop是一款处理以像素所构成的平面数字图像的软件，在软件中可以对图片进行编辑、修改、扫描、制作、图像输入输出。在项目中使用Photoshop，可以快速的制作项目中所需要的UI，并可以通过图层叠加的方式创建更加优秀的UI图像。  
Photoshop在游戏制作领域应用的十分广泛，不光可以制作简单的游戏UI，更可以通过配合其他3d建模软件，完成模型的贴图制作。  

### 3ds Max

3ds Max 是Autodesk 公司出品的最流行的三维动画制作软件，它提供了强大的基于Windows 平台的实时三维建模、渲染和动画设计等功能，被广泛应用于广告、影视、工业设计、多媒体制作及工程可视化领域。  
在项目中，使用3ds Max软件，进行场景的建模以及改动，并配合其他图片绘制软件完成模型的材质制作。  

### MySql

MySQL是一个小型的开源的关系型数据库管理系统，与其他大型数据库管理系统例如Oracle、DB2、SQL Server等相比，MySQL规模小且功能有限，但是它体积小、速度快、成本低，且它提供的功能对稍微复杂的应用已经够用，这些特性使得MySQL成为世界上最受欢迎的开放源代码数据库。  
MySql的管理方式也是很好的选择，可以利用数据库语句快速的遍历查询数据库，对数据库中的内容进行快速的增删改查。并在其中提供了多种API接口，支持多种开发语言。  

## 第3章 需求分析

### 需求分析

#### 用户群体

《虚拟仿真游戏》的用户群体主要面向于购买商品的消费者，以及售卖商品的商家，通过使用《虚拟仿真游戏》可以让用户更加清楚明白的在看到商品实物前，就能清晰的了解到商品的样式等基本信息，并可以让商家更加方便的向消费者展示所销售商品的特点。  

#### 需求场景分析

小张是一名普通大学生，有一天发现自己在校园中用作代步的自行车损坏了，于是他想去网购一辆新的自行车，但是在使用网购APP查看要买的商品时，却发现简单的2d图片不能够让其360度无死角的查看商品的细节，于是他向商家询问。而商家正好在之前使用过《虚拟仿真游戏》软件，于是商家指导小张下载并登录了被分配查看自行车模型权限的账号，小张得以更加清晰的查看他想购买商品的细节。通过这种方式，小张和商家快速达成了交易，并减少了可能存在的潜在问题。  

### 系统需求分析

通过以上需求场景分析《虚拟仿真游戏》可以满足用户最购物中出现的无法直观、准确的查看商品详情的问题进行了解决，并同时解决了商家对产品宣传不便的问题。  
能快速的购买的自己心爱的商品是我们每一个消费者都想达成的目的，但只是通过2d的图片总是无法能够直观的查看到商品的全貌，只有通过这种虚拟仿真技术，利用3d模型对现实物品的仿真技术，才能让消费者更加清晰快捷的查看到想购买物品的样式与功能细节。  
用户打开《虚拟仿真游戏》，首先进入用户登录界面，登录管理员账号后，会进入对应的管理端界面，当登录的账号为用户账号时，会进入用户账号。  
管理端可以通过简单UI对服务器中现有的模型进行修改与删除，并可以加载本地模型，将本地模型上传到服务器。  
在管理员界面还可以对用户信息进行修改，可以修改不同用户所对应的不同用户组，以让用户可以访问属于自己分配组内的模型。  
用户端可以查看用户对应用户组内所允许查看的模型，并可以对摄像机进行移动操作，来全方位的查看模型的细节。  
根据以上的基本流程，绘制了《虚拟仿真游戏》基本流程图，如图 3.1所示。  
![图 3.1](https://img-cdn.ccrui.cn.xyz/2022/05/21/ZwI1asBb2K.png)  

根据图 3.1基本流程图的分析，绘制出了用户用例图，如图 3.2所示。  
![图 3.2](https://img-cdn.ccrui.cn.xyz/2022/05/21/Ns5XUnbzhR.png)  

管理员可以进行上传模型、更改模型组、预览模型、注册用户、删除用户、更改用户组、给用户分配权限等行为。用户可以进行预览模型、移动相机、旋转相机、查看模型细节的行为。  
管理员行为功能如表 3.1所示。  

![表 3.1](https://img-cdn.ccrui.cn.xyz/2022/05/21/eydhYhIhNF.png)  
用户行为功能如表 3.2所示。  
![表 3.2](https://img-cdn.ccrui.cn.xyz/2022/05/21/mY5s9HJqxL.png)  

1. 上传模型
    用例描述如表 3.3所示。  
    ![表 3.3 ](https://img-cdn.ccrui.cn.xyz/2022/05/21/itQ0QtCwFT.png)  
2. 更改模型组
   用例描述如表 3.4所示。  
   ![表 3.4](https://img-cdn.ccrui.cn.xyz/2022/05/21/qIE9z4NDBK.png)  
3. 注册用户
   用例描述如表 3.5所示。  
   ![表 3.5](https://img-cdn.ccrui.cn.xyz/2022/05/21/KQwGOwB9tT.png)  
4. 预览模型
   用例描述如表 3.6所示。  
   ![表 3.6](https://img-cdn.ccrui.cn.xyz/2022/05/21/JTDufJhvek.png)  

### 系统运行环境

####  前端程序

（1）运行在Android4.4以上的手机系统版本。  
（2）运行在Windows7以上的Windows系统版本。  
（3）运行在Linux系统。  
（4）RAM内部存储为2G以上的设备。  
（5）ROM存储为500M以上的设备。  

#### 后端程序

（1）运行在部署Docker环境的全部服务器。  
（2）RAM内部存储为128M以上的设备。  

### 系统可行性分析

#### 技术可行性

《虚拟仿真游戏》该全平台程序的实现采用Unity3D游戏引擎，和C#脚本语言进行驱动，后台采用ASP.NET Core技术进行制作，并通过HTTP方式与前端程序进行数据的交换，数据库采用MySql数据库进行数据的存储。  
在《虚拟仿真游戏》中，Unity作为客户端，ASP.NET Core作为服务端，MySql作为数据库，对象存储作为数据存储位置。数据从客户端发送到服务端，服务端将数据处理并保存到MySql数据库中，将文件传输到对象存储中。  
综上所述，《虚拟仿真游戏》的技术可行性较高。  

#### 系统安全可行性

由于《虚拟仿真游戏》的全端实现由我一人完成，所以数据来源安全可靠稳定。后台采用ASP.NET Core作为服务器开发框架，使用Docker技术部署在全平台，给客户端（Unity）与数据库进行发送数据，所以《虚拟仿真游戏》是相对安全可靠的。  
于此同时，使用Unity3D开发的程序是以C#进行脚本语言驱动开发，在其中所使用的大量变量均为私有变量，并正确的设置其保护类型。后端采用的ASP.NET Core框架也是采用C#作为开发语言，并且在开发过程中数据库中所保存的全部敏感信息全部进行了加密处理，在Unity与服务器进行数据交换过程中使用Token验证可信权限，并且采用的全部接口均为Post接口，传输的数据均使用MD5加密方式进行数据加密。使用以上技术开发的《虚拟现实仿真游戏》的安全性不言而喻。  

#### 系统可行性分析

总之，《虚拟仿真游戏》作为一款全平台解决方案，无论是从安全可行性、经济可行性、技术可行性、可维护性、功能设定上都是遵循现代软件设计规律，符合完成解决方案的设计方法，系统设计可行性较高。  

## 第4章 系统设计

### 设计指导思想和原则

#### 指导思想

通过前期调研结果以及实践经验，详细分析《虚拟仿真游戏》的功能需求，在此之后，对项目进行设计与研发。  
首先做好前期的准备工作，绘制项目草图，流程图等，确定场景UI风格，进行内容设计，功能需求分析，代码框架设计的工作，其次，利用后端框架完成后端服务器的制作与搭建。并利用Photoshop、3ds Max等工具，制作所需的美术资源，并根据草图在Unity中搭建功能所需的基本场景以及编写脚本代码。同时将制作好的美术资源部署于Unity场景中。及时发现并修改在设计上存在的问题，并将Unity与后端框架使用HTTP连接的方式进行通讯链接。待场景全部完成后，对场景与后端进行反复测试，尽可能的减少功能中存在的Bug，提高整体的用户体验。  

#### 设计原则

为保证《虚拟仿真游戏》系统的成功实现，在设计制作过程中，遵循以下原则：  
（1）确保场景风格统一。  
（2）遵循设计原则，注重场景一致性，不过于简单也不过于花哨。  
（3）根据项目需求进行设计，突出项目主要功能。  
（4）UI中的字体、字号等符合场景设计原则。  
（5）文字表达部分简单明了。  
（6）对所有用户操作均有明确的操作完成提示。  
（7）对网络连接问题，进行加密传输。  
在研发制作过程中，对于代码框架以及代码管理，遵循以下原则：  
（1）脚本的命名与变量的命名严格遵循C#语法要求采用驼峰命名法。  
（2）脚本与变量的命名清晰明了，并有意义。  
（3）整体代码框架设计简介明了，避免耦合性过高降低可读性。  
（4）对脚本进行分类管理。  
（5）对需要多次复用的功能，进行封装复用。  
（6）优化代码逻辑，减少内存占用。  
在功能内容设计上，遵循以下的原则：  
（1）根据用户需求进行设计与实现。  
（2）在满足用户功能的条件上，尽量减少用户的使用难度。  
（3）尽量减少无用功能，减少用户理解难度。  
（4）做到及时反馈，提高用户体验。  

### 系统流程设计 

通过以上对《虚拟仿真游戏》的功能需求分析以及设计分析，将对其操作流程做出以下设计。  
管理员使用管理员账号登录管理端，并使用上传功能，将制作好的模型上传到服务器中，并向模型进行分配模型组权限，并使用用户管理工具，注册新的用户账号，并将用户分配不同的用户组中。用户使用用户账号登录后，即可进入用户端，用户可以通过点击左侧模型区的模型预览图，对服务器中有权限访问的模型进行下载并实例化在画面中心，通过移动摄像机的方式，360度的查看模型的细节。  
《虚拟仿真游戏》流程图如图 4.1所示  
![图 4.1](https://img-cdn.ccrui.cn.xyz/2022/05/21/VgE5YNDNNR.png)  

本项目中采用ASP.NET Core技术搭建服务器应用，并通过Swagger撰写接口文档。本项目中全部API接口均采用HTTP Post链接方式进行通讯，除登录接口外，全部接口均需向服务器提供服务器可信Token进行鉴权操作。API返回值均为统一处理格式，方便前端接入时处理数据。  
其中接口包括以下8个：  

1. Register  
   ![表 4.1](https://img-cdn.ccrui.cn.xyz/2022/05/21/kJvBFUGTtZ.png)  
2. Loading  
   ![表 4.2](https://img-cdn.ccrui.cn.xyz/2022/05/21/NLb0ViIIf9.png)  
3. Cancellation  
   ![表 4.3](https://img-cdn.ccrui.cn.xyz/2022/05/21/0UPsGgM7bH.png)  
4. GetUserInformation  
   ![表 4.4](https://img-cdn.ccrui.cn.xyz/2022/05/21/OoirQ1chMk.png)  
5. AddAB  
   ![表 4.5](https://img-cdn.ccrui.cn.xyz/2022/05/21/XklYrXzCxI.png)  
6. DelAB  
   ![表 4.6](https://img-cdn.ccrui.cn.xyz/2022/05/21/jmsfizbTK0.png)  
7. UpDataAB  
   ![表 4.7](https://img-cdn.ccrui.cn.xyz/2022/05/21/vuJdpHYXpk.png)  
8. ShowABPackage  
   ![表 4.8](https://img-cdn.ccrui.cn.xyz/2022/05/21/zMkE9Zds3y.png)  

### 系统功能模块详细设计

#### 登录功能模块设计

登录功能是已经完成注册的用户，输入用户邮箱和密码，并将用户名和密码上传到服务器端，由服务器进行身份验证，并返回用户权限与登录是否成功，在登录后返回Token以帮助服务器对用户动作进行鉴权。  
功能主要包含UGUI中的Image图片组件、InputField输入框组件、Button按钮组件、Text文本组件。在用户输入用户名和密码后，点击登录按钮，调用封装好的HTTP方法，向服务器发送登录请求，并在后端数据库中对用户名与密码进行身份验证，并将服务器返回信息处理后显示在用户界面。
根据登录功能模块的设计绘制了登录功能的时序图，如图 4.2所示。  
![图 4.2](https://img-cdn.ccrui.cn.xyz/2022/05/21/vvxaDB8gfL.png)  

#### 模型库模块设计

模型库模块是用来显示用户所在用户组所能查看的全部模型，在用户登录完成后，模型库模块会自动调用封装好的HTTP模块向服务器发出Post请求，服务器在鉴权成功后，向客户端返回全部模型预览图的链接与模型链接，模型库会自动根据预览图加载图片显示在UI中，并且在用户点击预览模型后，通过模型下载链接，从服务器拉取模型进行实例化，并在完成后向用户发出通知。  
根据模型库模块设计绘制了模型库模块的时序图，如图 4.3所示。  
![图 4.3](https://img-cdn.ccrui.cn.xyz/2022/05/21/TiYaamnGAQ.png)  

#### 用户管理模块设计

用户管理模块是项目中，可以供管理员对用户信息进行管理的模块，在本模块设计中，要充分让管理员简单方便的对用户信息进行管理。管理员在选择用户管理模块后可以进行新建用户、修改用户组、修改用户密码、删除用户等操作。在本模块的设置中，管理员对用户信息进行任何修改时，服务器都会对管理员权限做一次额外认证，保证权限正确。  
根据用户管理模块设计绘制了用户管理模块的时序图，如图 4.4所示。  
![图 4.4](https://img-cdn.ccrui.cn.xyz/2022/05/21/vWnBmXhzRE.png)  

#### 相机控制模块设计

相机控制模块是项目中用户端和管理复用的通用模块，用户在实例化完成模型后即可通过点击移动鼠标的方式，或者滑动屏幕的方式，控制摄像机的旋转、移动、缩放等功能。  

#### 工具类模块设计

在项目中总是出现一些需要全局多次使用的方法，可以将其封装成对应静态工具类，当需要工具类功能时，可直接调用静态方法实现功能，可以减少项目的内存占用与减少可能出现的逻辑冲突。  
根据工具类模块设计绘制了工具类模块的时序图，如图 4.5所示。  
![图 4.5](https://img-cdn.ccrui.cn.xyz/2022/05/21/XbiX8Eikqs.png)  

#### 全局通知类模块设计

在场景中，每次用户进行操作后，均应该向用户返回操作结果，并显示在UI中。全局通知类模块便是封装好的全局通知类，当需要通知时，通过单例模式调用模块便可实现通知显示。

#### 后端API类模块设计

该项目中，拥有一套完整的后端API，项目的大部分逻辑依靠后端支撑。在前端程序向后端程序请求时，后端程序应该争取处理请求信息，并在处理后将正确的返回值格式化后返回供前端使用。

### 用户体验设计

《虚拟仿真游戏》主要面向于普通消费者和普通商家设计的，所以界面的整体风格简单明了，易于使用，在界面的表达上要做到简单明了方便使用。  
简单快速上手使用是消费者和商家共同的目标，所以如何让用户在使用《虚拟仿真游戏》时能够轻松使用，并尽量减少会使用户感到困惑的界面与文案，那么就要做到以下原则：  

1. 《虚拟仿真游戏》界面表达上做到简单明了，采用大色块的风格，突出每个模块之间的联系，并且适配多种系统，让用户无论是通过键鼠使用亦或是通过触控设备使用时都能以直觉方式进行操作。
2. 减少界面中的可能令用户产生疑惑的部分，全部文案简单易懂，让用户更加容易的理解各模块代表的含义。
3. 《虚拟仿真游戏》的整体设计应符合基本软件设计的原则，做到UI风格统一，色彩搭配合理，界面元素排版合理等。

### 系统界面设计

#### 登录界面

在进入《虚拟仿真游戏》后首先展示的是用户登录界面，在用户界面中包括图片、输入框、按钮等元素，并通过强调色视觉引导配合文字引导的方式，引导用户正确的输入账号密码。  
其中图片、输入框、按钮等元素均为Unity3D自带的UGUI系统制作。  
登录界面效果图，如图 4.6所示。  
![图 4.6](https://img-cdn.ccrui.cn.xyz/2022/05/21/swp7JELsex.png)  

#### 用户界面

用户界面采用色块堆叠配色，并由于用户使用功能较少，将界面主要分为三部分，模型选择部分、模型展示部分、其他功能部分。  
模型选择部分采用Unity3D中自带的UGUI组件，利用其中的Scroll Rect、Grid Layout Froup、Content Size Fitter、Toggle Group组件完成模型选择部分的弹性UI显示。  
模型展示部分，在用户未加载预览模型时，显示为空，只有当用户选择并加载模型后，模型才会在画面中心位置实例化出来，用户可以在中间部分使用鼠标或触控设备滑动以旋转、移动、缩放模型。  
其他功能部分采用Unity3D中自带的UGUI组件，利用其中的Button、Slider组件完成返回登录、刷新场景、相机归位、控制自动旋转速度功能。  
用户界面效果图如图 4.7图 4.8所示。  
![图 4.7](https://img-cdn.ccrui.cn.xyz/2022/05/21/SOIVsXmhfc.png)
![图 4.8](https://img-cdn.ccrui.cn.xyz/2022/05/21/6jYGehgdaL.png)

#### 管理界面
管理界面与用户界面相同，同样采用色块堆叠配色方式，并由于管理员使用功能较多，将界面主要分为模型选择部分，模型修改部分，模型展示部分，用户选择部分，用户修改部分，本地选择部分，其他部分。  
模型选择部分与用户界面相同，均采用Unity3D中自带的UGUI组件，利用组件特性完成弹性UI显示。  
模型修改部分，采用UGUI组件中Button、InputField、Image组件完成对选择模型的加载、删除、更新模型组的操作。  
用户选择部分，采用UGUI组件中Image、Scroll Rect、Grid Layout Froup、Content Size Fitter、Toggle Group组件完成用户选择部分的弹性UI显示。  
用户修改部分，采用UGUI组件中Button、InputField、Image组件完成对用户信息的注册、修改、删除用户等操作。  
本地选择部分，在用户点击“预览模型”按钮后会出现本地文件选择器，可通过选择器选择需要上传的模型文件，在确定选择后，会在模型展示部分展示模型情况，并当用户点击“上传”按钮后将模型上传到服务器。
管理界面效果图如图 4.9图 4.10图 4.11所示。  
![图 4.9](https://img-cdn.ccrui.cn.xyz/2022/05/21/PMTtxCMc3S.png)  
![图 4.10](https://img-cdn.ccrui.cn.xyz/2022/05/21/oVytmfCmk7.png)  
![图 4.11](https://img-cdn.ccrui.cn.xyz/2022/05/21/t5PKtODXnV.png)  

## 第5章 系统实现

### 场景切换模块实现

场景切换模块，对于使用的用户来说应当是无感的，在打开程序时，首先加载空场景，在其中初始化需要单例模式与切换场景时不删除的GameManager模块与NoticeManager模块。  
加载完成空场景模块时，同步加载登录模块，这样可以让用户在进入游戏时，可以快速加载场景而不会出现卡顿情况。  
场景切换模块实现流程如图 5.1所示。  
![图 5.1](https://img-cdn.ccrui.cn.xyz/2022/05/21/b6gyvZCqpU.png)  
对应主要代码如下：  

``` csharp
public static GameManager Instance { get; private set; }
private void Awake()
{
    Instance = this;
    DontDestroyOnLoad(this);
}
private void Start()
{
    SceneManager.LoadScene("Login");
}

```

### 登录模块实现

登录模块为用户进入应用程序首先发挥作用的模块，用户在登录模块中输入账号与密码，登录模块通过HTTP与服务器进行通讯，完成用户的鉴权，并返回用户是否成功登录。  
登录模块实现流程图如图 5.2所示。  
![图 5.2](https://img-cdn.ccrui.cn.xyz/2022/05/21/OYxRfZXy1n.png)  
客户端对应主要代码如下：  

``` csharp
public void StartLoading()
{
    JsonData = new JsonData();
    jsonData["Md5Email"]= Md5.ToCalculateMd5(emailText.text);
    jsonData["Md5Password"]=Md5.ToCalculateMd5(password.text);
    var webRequest=GameManager.Instance.GetComponent<WebRequest>();
    webRequest.Post(GameManager.Instance.url+url, ((code, request, rsponse) =>
    {
        if (rsponse.code==200)
        {
            var a=JsonConvert.DeserializeObject<Tool.ReturnClass>(rsponse.text);
            GameManager.Instance.userData.openId
                = Md5.ToCalculateMd5(emailText.text);
            GameManager.Instance.userData.email = emailText.text;
            GameManager.Instance.userData.password = password.text;
            GameManager.Instance.userData.token = a.data.token;
            GameManager.Instance.userData.@group = a.data.group;
            if (a.data.group!=0)
            {
                SceneManager.LoadScene("VirtualSimulation");
            }
            else
            {
                SceneManager.LoadScene("Admin");
            }
        }
        else
        {
            Debug.LogWarning(rsponse.text);
            try
            {
                var a=JsonConvert.DeserializeObject<ToolReturnClass>(rsponse.text);
                Notice.Instance.AccordingToNotice(a.messass,Color.red, true,null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Notice.Instance.AccordingToNotice("登录失败 请检查服务器链接",Color.red, true,null);
                throw;
            }
        }
    }),jsonData,"");

```

### 模型加载模块实现

模型加载模块，用于在用户登录后，向后端请求用户权限内全部模型的链接，并将链接暂存到项目内存中，通过获取到的模型预览图链接加载模型预览图显示到项目UI中。  
模型加载模块实现流程图如图 5.3所示。  
![图 5.3](https://img-cdn.ccrui.cn.xyz/2022/05/21/1azZ96Pa6i.png)  
客户端对应主要代码如下：  

``` csharp
public void Load()
{
    JsonData jsonData = new JsonData();
    jsonData["openid"] = GameManager.Instance.userData.openId;
    jsonData["password"] 
= Md5.ToCalculateMd5(GameManager.Instance.userData.password);

    var webRequest = GameManager.Instance.GetComponent<WebRequest>();
    webRequest.Post(GameManager.Instance.url + url, (
        (code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);

            if (rsponse.code == 200)
            {
                var a = JsonConvert.DeserializeObject<Tool.ReturnClassList>(rsponse.text);

                // Debug.Log(a.data);

                foreach (var data in a.data)
                {
                    var _showABPackageReturn = new ShowABPackageReturn
                    {
                        Id = data.id,
                        Name = data.name,
                        Image = "https://kai.chengrui.xyz/VirtualSimulation/Image/" + data.image,
                        AB = "https://kai.chengrui.xyz/VirtualSimulation/AssetBundles/" + data.ab,
                        Group = data.group
                    };
                    showAbPackageReturns.Add(_showABPackageReturn);

                    GameObject g = Instantiate(displayBoxContent, this.transform);
                    displayBoxContentList.Add(g);
                    g.GetComponent<Toggle>().group = this.GetComponent<ToggleGroup>();
                    g.GetComponent<DisplayBoxContent>().showAbPackageReturn = _showABPackageReturn;
                }
            }
            else
            {
                try
                {
                    var a= JsonConvert.DeserializeObject<ReturnClassList>(rsponse.text);
                    Notice.Instance.AccordingToNotice(a.messass, Color.red, true, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Notice.Instance.AccordingToNotice("登陆失败 请检查服务器链接", Color.red, true, null);
                    throw;
                }
            }
        }), jsonData, GameManager.Instance.userData.token);
}

```

### 模型显示模块实现
模型显示模块主要在用户选择模型后，从本地缓存的模型链接中下载模型并实例化。  
模型显示模块实现流程图如图 5.3所示。  
![图 5.3](https://img-cdn.ccrui.cn.xyz/2022/05/21/imUTmvAwj4.png)  
客户端对应主要代码如下：  

``` csharp
/// <summary>
/// 下载并展示AB包
/// </summary>
private void LoadChooseToAB()
{
    if (_toggle.isOn)
    {
        try
        {
            if (ABgameobject == null)
            {
                EventCenter.Broadcast(ENventType.UpdateAB);
                Debug.Log("收到加载广播");
                StartCoroutine(InstantiateObject(showAbPackageReturn.AB, (
                    ab =>
                    {
                        AB = ab;
                        ABgameobject=Instantiate(ab.LoadAsset<GameObject>(showAbPackageReturn.Name));Notice.Instance.AccordingToNotice("加载成功",Color.green, true,null);
                    })));
            }
            else
            {
                Debug.Log("模型已被实例化");
                Notice.Instance.AccordingToNotice("模型已被实例化",Color.green, true,null);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Notice.Instance.AccordingToNotice(e.Message,Color.red, true,null);
            throw;
        }
    }
}

```

### 相机移动模块实现
相机移动是用户全方位查看模型的一个良好解决方法，本项目中，用户可以使用鼠标左键点击后拖动来控制相机的围绕旋转，使用鼠标右键点击拖动可实现相机的平行移动，使用鼠标滚轮可实现模型缩放，并且在触屏设备上，可以使用单指拖动的方式控制相机旋转，双指拖动的方式控制相机平移，双指缩放的方式，控制相机缩放。  
相机移动模块客户端对应主要代码如下。  

``` csharp
/// <summary>
/// 摄像机移动
/// </summary>
/// <param name="x">X轴移动数据</param>
/// <param name="y">Y轴移动数据</param>
private void CameraMove(float x, float y)
{
    transform.Translate(Vector3.left * (x * 
GameManager.Instance.camaraOperation.cameraMoveSpeed 
* Time.deltaTime));
    transform.Translate(Vector3.up * (y * 
GameManager.Instance.camaraOperation.cameraMoveSpeed 
* Time.deltaTime));
}
/// <summary>
/// 摄像机旋转
/// </summary>
/// <param name="x">X轴移动数据</param>
/// <param name="y">Y轴移动数据</param>
private void Rotate(float x, float y)
{
    //左右旋转
    Transform transform1;
    transform1 = this.transform;
    //左右旋转
    transform1.RotateAround(_target.transform.position, Vector3.up, x * 5);    
    //分拆旋转数值
    float a = transform1.rotation.eulerAngles.x;
    if (a > 180)
    {
        a -= 360.0f;
    }
    //分拆处理上下旋转最大值
    if (y > 0)
    {
        if (a < GameManager.Instance.camaraLocationLimit.camaraAngle.y)
        {
    //上下旋转
            transform.RotateAround(_target.transform.position, transform.right, y * 5); 
        }
    }
    else if (y < GameManager.Instance.camaraLocationLimit.camaraAngle.x)
    {
        if (a > 0)
        {
    //上下旋转
            transform.RotateAround(_target.transform.position, transform.right, y * 5); 
        }
    }
}

```

### 模型上传模块实现
模型上传模块，是管理员管理模型的一个主要方法，管理员点击预览本地模型后，在查看模型无误，设定模型组后，即可将模型上传到服务器，服务器对管理员身份进行验证成功后，将模型保存到对象存储，并且将下载路径保存至数据库中。  
模型上传模块实现流程图如图 5.4所示。  
![图 5.4](https://img-cdn.ccrui.cn.xyz/2022/05/21/IOjHLZyvhG.png)  

``` csharp
/// <summary>
/// 上传AB包
/// </summary>
public void Upload()
{
   if (ABbyte != null && ABname != null && ABgameobject != null)
   {
      string group;
      //判断用户组是否为空
      if (String.IsNullOrEmpty(inputField.text))
      {
         group = "1";
      }
      else
      {
         group = inputField.text;
      }
      var webRequest=GameManager.Instance.GetComponent<WebRequest>();
      JsonData = new JsonData();
      jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
      jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
      jsonData["name"] = ABname;
      jsonData["image"] = Screenshots.StartScreenshots(screenshotTheCamera);
      jsonData["ab"] = Convert.ToBase64String(ABbyte);
      jsonData["group"] = group;
      GameObject _g = Notice.Instance.AccordingToNotice("正在上传", null, false, null);
      webRequest.Post(GameManager.Instance.url+url, ((code, request, rsponse) =>
      {
         Debug.Log(rsponse.text);
         if (rsponse.code==200)
         {
            EventCenter.Broadcast(ENventType.UpdateData);
            Notice.Instance.CloseToInform(_g);
            var a=JsonConvert.DeserializeObject<Tool.ReturnClass>(rsponse.text);
            Notice.Instance.AccordingToNotice(a.messass,Color.green, true,null);
         }
         else
         {
            Notice.Instance.CloseToInform(_g);
            Notice.Instance.AccordingToNotice("上传失败",Color.red, true,null);
         }

      }),jsonData,GameManager.Instance.userData.token);
   }
   else
   {
      Debug.Log("未选择AB包");
      Notice.Instance.AccordingToNotice("未选择AB包",Color.red, true,null);
   }
}

```

### 用户信息展示模块实现
用户信息展示模块，是管理员管理全部用户信息的重要模块，在此模块中，管理员可查看全部用户基本信息，并对用户进行注册、删除、修改密码、修改用户组等操作。  
用户信息展示模块实现流程图如图 5.5所示。  
![图 5.5](https://img-cdn.ccrui.cn.xyz/2022/05/21/m6WaQ2MIZb.png)  
用户信息展示模块客户端对应主要代码如下：  

``` csharp
/// <summary>
/// 加载用户数据
/// </summary>
private void LoadingUserData()
{
    var webRequest= GameManager.Instance.GetComponent<WebRequest>();

    JsonData = new JsonData();
    jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
    jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
    webRequest.Post(GameManager.Instance.url+_url, ((code, request, rsponse) =>
    {
        Debug.Log(rsponse.text);
        if (rsponse.code==200)
        {
            var a=JsonConvert.DeserializeObject<Tool.ReturnClassList>(rsponse.text);
            foreach (var _data in a.data)
            {
                GameObject g= Instantiate(userPrefab,this.transform);
                users.Add(g);
                g.GetComponent<Toggle>().group = this.GetComponent<ToggleGroup>();
                g.GetComponent<UserDataBox>().email.text = _data.email;
                g.GetComponent<UserDataBox>().@group.text = _data.@group.ToString();
                UserDatas.Add(new UserData
                {
                    openID = _data.openID,
                    email = _data.email,
                    @group = _data.@group,
                });
            }
            
        }
        else
        {
            try
            {
                var a=JsonConvert.DeserializeObject<ReturnClassList>(rsponse.text);
                Notice.Instance.AccordingToNotice(a.messass,Color.red, true,null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Notice.Instance.AccordingToNotice("登录失败 请检查服务器链接",Color.red, true,null);
                throw;
            }
        }
    }),jsonData,GameManager.Instance.userData.token);
}

```

## 第6章 系统测试

### 系统测试方法

因为《虚拟仿真游戏》是一款全平台游戏应用，所以系统测试也可以叫软件测试，软件测试方法，简单来说就是测试软件的方法，软件测试是开发软件中非常重要的环节，软件测试方法分为单元测试、集成测试、白盒测试、黑盒测试等《虚拟仿真游戏》主要采用的是UI测试、白盒测试、黑盒测试。  

### 《虚拟仿真游戏》功能模块测试及结果

#### 登录功能测试

登录功能，是正常使用《虚拟仿真游戏》的关键前提，首先，我们需要测试登录功能是否正常，我们需要在本地或在服务器部署Docker容器，在其中运行后端服务器程序，保证后台程序运行正常，测试过程如下。  
测试项目：登录功能是否正常。  
测试用例：当用户打开《虚拟仿真游戏》，显示登录界面，输入已在数据库中录入的注册信息，即输入用户邮箱和密码，点击登录，查看是否可以顺利登录。  
测试流程：根据登录的测试用例方法，进行反复的登录操作，至少使用十位已注册用户信息，测试登录二十次。在登录功能测试的过程中，要着重测试输入用户信息不合法或输入错误的情况，查看《虚拟仿真游戏》是否能给予用户正确的信息返回。  
测试结果：输入正确用户信息登录时如图 6.1所示，正常进入对应场景。输入错误用户信息登录时如图 6.2所示，有明显提示。测试完成后，一切运行正常，未出现漏洞。  
![图 6.1](https://img-cdn.ccrui.cn.xyz/2022/05/21/JSMgrZtLRU.png)  
![图 6.2](https://img-cdn.ccrui.cn.xyz/2022/05/21/SJUXvU4aJX.png)  

#### 模型显示测试

模型显示，是查看模型情况的重要功能，测试模型显示前需正确登录已有账号，测试过程如下。  
测试项目：模型显示功能是否正常。  
测试用例：当用户进入客户端或管理端后，点击左侧模型预览图后，并点击加载模型，查看模型是否正确在画面中显示。  
测试流程：根据模型显示测试用例方法，进行反复的加载模型操作，至少测试五个云端模型显示。在模型显示测试的过程中，要着重测试加载云端大模型时，是否在加载时会给予用户良好的提示，并在模型加载成功后是否给予用户正确的信息反馈，模型加载失败时，是否给与用户正确的信息返回。  
测试结果：点击云端模型并加载过程时如图 6.3所示，模型加载成功时如图 6.4所示，模型加载失败时如图 6.5所示。测试完成后，一切运行正常，未出现漏洞。  
![图 6.3](https://img-cdn.ccrui.cn.xyz/2022/05/21/vCpD9gLXO9.png)  
![图 6.4](https://img-cdn.ccrui.cn.xyz/2022/05/21/8du81sKSiF.png)  
![图 6.5](https://img-cdn.ccrui.cn.xyz/2022/05/21/O8ApVQtAk4.png)  

#### 上传模型测试

上传模型，是管理员对模型库进行管理的有效方法，在上传模型前需正确登录管理员账号，测试过程如下。  
测试项目：模型上传功能是否正常，上传错误模型是否可正确返回。  
测试用例：当用户进入管理端后，点击预览模型，预览需要上传的模型后，设定模型组后，点击上传按钮，查看模型是否上传成功。  
测试流程：根据上传模型测试用例方法，进行反复的上传模型操作，至少测试五个模型的预览与上传，并选择至少五次错误模型格式进行上传，在上传模型测试的过程中要着重测试上传错误模型时候，是否会给予用户正确的信息反馈，模型上传成功后是否会给予用户正确的信息返回。  
测试结果：点击预览模型选择正确模型并上传成功如图 6.6所示，点击预览模型选择错误模型并上传如图 6.7所示，未选择模型直接点击上传如图 6.8所示。测试完成后，一切运行正常，未出现漏洞。  
![图 6.6](https://img-cdn.ccrui.cn.xyz/2022/05/21/rbtgdJIXh7.png)  
![图 6.7](https://img-cdn.ccrui.cn.xyz/2022/05/21/obSwMzjaWm.png)  
![图 6.8](https://img-cdn.ccrui.cn.xyz/2022/05/21/oFtYMlf1mm.png)  

#### 修改用户信息测试

修改用户信息是管理员对用户管理的良好方式，修改用户信息需正确登录管理员账号，测试过程如下。  
测试项目：修改用户功能是否正常。  
测试用例：当用户进入管理端后，点击右侧选择用户后，输入新的密码或用户组，查看是否正确修改用户信息。  
测试流程：根据修改用户信息测试用例方法，进行反复的修改用户信息操作，至少测试十次修改用户信息。在测试修改用户信息过程中，要着重测试修改用户信息不合法的情况，将唯一管理员权限修改为普通用户权限，并在各种情况下均给予用户友好的信息返回。  
测试结果，正确修改用户信息如图 6.9所示，修改用户信息不合法时如图 6.10所示，修改唯一管理员权限时候如图 6.11所示。  
![图 6.9](https://img-cdn.ccrui.cn.xyz/2022/05/21/bS8zV45eXd.png)  
![图 6.10](https://img-cdn.ccrui.cn.xyz/2022/05/21/qeRY1rMRZ2.png)  
![图 6.11](https://img-cdn.ccrui.cn.xyz/2022/05/21/j8F3LZxwdp.png)  

### 测试结论

经过对《虚拟仿真游戏》的主要功能进行了反复的用例测试，检验了《虚拟仿真游戏》的运行正常，并将发现的问题以及漏洞及时改正，使得《虚拟仿真游戏》无论是程序可靠性，还是在用户体验上都得到了进一步的提升，界面得到了进一步的美化，功能上得到了进一步的完善，简而言之，《虚拟仿真游戏》的测试，使得《虚拟仿真游戏》的各个当面都得到了进一步的优化。  
综上所述，《虚拟仿真游戏》的测试过程和测试结果，证明《虚拟仿真游戏》的各个方面运行正常，《虚拟仿真游戏》的测试基本成功，质量良好。  

## 第7章 结　论

虚拟现实技术承载了人类对未来科技的无限幻想，而未曾发现，其实这项技术早已围绕这我们生活中的方方面面。购物是现代人必不可少的一种休闲活动，因此设计了一个满足用户购物过程中能更加清晰明了的看到商品，管理者能更加方便的向用户展示商品细节的一整套解决方法。  
《虚拟仿真游戏》是通过游戏引擎搭建，将3d模型展示情景接入普通用户购物体验中的一个良好解决方案。通过《虚拟仿真游戏》消费者将可以简单方便的查看商品的全貌，卖家也可以通过该解决方案，向消费者更加快速准确的展示产品的优点。  
《虚拟仿真游戏》在项目技术实现上，是采用Unity作为客户端，以Docker技术配合ASP.NET Core技术搭建后端服务器，并通过对象存储配合CDN内容分发快速分发模型文件。该客户端可运行在多种终端上，包括PC机、移动端、浏览器端等，并在项目开发时，对以上平台均做出了体验优化。后端服务器通过Docker技术可以简单快速部署在不同种类的服务器。在前后端传输过程中采用了HTTP连接方式，前端程序向后端程序发起请求后，由后端程序对请求进行鉴权后返回前端所请求的文件与数据，并将前端请求的数据存入MySql数据库中。  
在本文论述部分，介绍了《虚拟仿真游戏》的设计背景，以及他的研究现状等方面的知识，让本项目的开发有了实现的价值。  
在第2章中，本文介绍了如何制作项目，与项目所需要的运行环境，以及在项目开发过程中所使用的技术，这部分的知识让《虚拟仿真游戏》的设计与实现从技术层面来说是可行的。  
第3章中，对项目进行了详细的需求分析，在需求分析的过程中，我们对项目的各项系统功能的可行性进行了充分的论证，并对项目的用户群体进行了详细的分析，对系统运行环境以及开发环境进行了简单论证，确定了《虚拟仿真游戏》项目是一个充满事实可行性的项目。  
第4章中，对已经完成分析后的具体项目需求，进行其系统性的设计，并根据设计原则，对《虚拟仿真游戏》进行了具体系统设计。  
第5章中，我们根据已经完成的系统设计，完成了《虚拟仿真游戏》的系统化实现，系统化实现中，实现了模块设计中的绝大部分的模块。  
综上所述可以看出《虚拟仿真游戏》其广阔的应用性，市场前景良好。  

## 参考文献

[1] 谢佩洪, 成立. 中国PC网络游戏行业商业模式创新的演化研究[J]. 科研管理, 2016, 37(10):9.  
[2] 高楠. 谈第九艺术的灵魂——三维游戏角色设计[J]. 中国科教创新导刊, 2014(4):1.  
[3] 来小鹏, 贺文奕. 论电子游戏画面的作品属性[J].  2021(2019-11):30-40.  
[4] 王圣葳. 浅析基于Unity3D的游戏开发[J]. 数码设计, 2021, 10(10):1.  
[5] 郭欣桐. 基于Unity的休闲益智类游戏设计与开发[J]. 电子技术与软件工程, 2021(1):3.  
[6] 张衡. 玩游戏也是一种工作——走近游戏策划师[J].  2021(2013-10):23-23.
[7] Doppioslash C. Your First Unity Shader[J]. 2018.  
[8] 苏珂, 续鲁庆. 游戏设计中基于DBN的用户体验评估模型研究[J]. 包装工程, 2020, 41(2):7.  
[9] 林书浩. 浅述Unity引擎简述与游戏制作流程[J]. 科学与信息化, 2020(17):2.  
[10] 查天贝. 游戏美术在手机游戏界面上的思考[J]. 数码世界, 2020(1):1.  
[11] 何剑. 游戏美术中地图与关卡编辑的课程设计[J].  2020.  
[12] 陈京炜. 游戏心理学[M]. 中国传媒大学出版社, 2015.  
[13] 李智, 张云龙, 赵涛,等. 基于Unity Shader实现对三维渲染效果的控制[J]. 价值工程, 2021, 40(16):2.  
[14] Alexiou A, Schippers M, Oshri I, et al. Narrative and aesthetics as antecedents of perceived learning in Serious Games[J]. Other publications TiSEM, 2020.  
[15]杜月林, 黄刚, 王峰,等. 建设虚拟仿真实验平台 探索创新人才培养模式[J]. 实验技术与管理, 2015, 32(12):4.  

## 致  谢

首先感谢张华振老师在本次论文撰写和毕业设计作品制作过程中对我进行科学严谨的指导，在论文撰写和毕设期间，张华振老师主动监督我的工作进度，督促我保质保量的完成毕设和论文撰写工作，并在我遇到困难时与我进行深入讨论和分析，帮助我解决难题，使我能够顺利完成论文撰写和毕设制作。  
感谢在大学时间里，高等职业技术学院全体老师与同学对我的帮助，没有各位老师同学的帮助，我可能没有充足信心完成论文的撰写与毕业设计，感谢虚拟现实19101班的全体同学，在大学时间里对我的种种鼓励与支持，让我逐渐成长。  
在制作本项目的过程中，我学习到了很多以往没有掌握牢靠的知识，更重要的是，我了解到了作为一名软件开发人员，如何从零开始开发一套完整的系统软件，如何克服种种困难完成系统的搭建，如何从不同的角度去思考问题、解决问题。通过这次的系统设计，我学会了很多，也了解到了很多。  
最后，还要向百忙中抽出时间来审阅本文的各位老师表示由衷的感谢。  
