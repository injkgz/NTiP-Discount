;------------------------------------------------------------------------------
;   ���������� ��������� ���������
;------------------------------------------------------------------------------
; ��� ����������
#define   Name       "Discount"
; ������ ����������
#define   Version    "1.1.3"
; �����-�����������
#define   Publisher  "injkgz"
; ���� ����� ������������
#define   URL        "https://vk.com/injecti0nkz"
; ��� ������������ ������
#define   ExeName    "Discount.exe"
;------------------------------------------------------------------------------
;   ��������� ���������
;------------------------------------------------------------------------------
[Setup]
; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{A89A0A05-6BB5-4296-93AB-2A8487428277}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=..\Discount-setup
OutputBaseFileName=Discount-setup

; ���� ������
SetupIconFile=ico.ico

; ��������� ������
Compression=lzma
SolidCompression=yes

;�������� ����������
ChangesAssociations = yes
;------------------------------------------------------------------------------
;   ������������� ����� ��� �������� ���������
;------------------------------------------------------------------------------
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl";
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";
;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]
; �������� ������ �� ������� �����
Name: "Discount"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: associate; Description: "&Associate files"; GroupDescription: "Other tasks:"; Flags: unchecked
;------------------------------------------------------------------------------
;   �����, ������� ���� �������� � ����� �����������
;------------------------------------------------------------------------------
[Files]

; ����������� ����
Source: "F:\REPOS\NTiP-Sales\DiscountForms\bin\Release\DiscountForms.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "F:\REPOS\NTiP-Sales\DiscountForms\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; .NET Framework 4.0
Source: "dotNetFx40_Full_x86_x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected
;------------------------------------------------------------------------------
;   ��������� �����������, ��� �� ������ ����� ������
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\ico.ico"
;------------------------------------------------------------------------------
;   ������ ���� ���������� �� ���������� �����
;------------------------------------------------------------------------------
[Code]
#include "dotnet.pas"

[Run]
;------------------------------------------------------------------------------
;   ������ ������� ����� �����������
;------------------------------------------------------------------------------
Filename: {tmp}\dotNetFx40_Full_x86_x64.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft Framework 4.0 is installed. Please wait...

[Registry]

Root: HKCR; Subkey: ".cardDB";                             ValueData: "{#Name}";          Flags: uninsdeletevalue; ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}";                     ValueData: "Program {#Name}";  Flags: uninsdeletekey;   ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}\DefaultIcon";             ValueData: "{app}\{#Name},0";               ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}\shell\open\command";  ValueData: """{app}\{#Name}"" ""%1""";  ValueType: string;  ValueName: ""