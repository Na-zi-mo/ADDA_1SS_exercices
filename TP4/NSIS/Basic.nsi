;Adapté par Frédéric Monchamp. 
;Exemple basé sur :
;NSIS Modern User Interface
;Basic Example Script
;Written by Joost Verburg

;--------------------------------
;Inclusion Modern UI

  !include "MUI2.nsh"

;--------------------------------
;Les defines

  !define NOM_APP "Meteo-2203680"
  !define NOM_EXE "TP4"

  ;Icone de l'installateur
  !define MUI_ICON ".\cloud_weather.ico"

;--------------------------------
;Variables

  Var DossierMenuDemarrer

;--------------------------------
;Général

  ;Nom de l'application
  Name "${NOM_APP}"

  ;Nom du fichier de l'installateur
  OutFile "${NOM_APP}.exe"
  Unicode True

  ;Dossier d'installation par défaut
  ;InstallDir "$LOCALAPPDATA\${NOM_APP}"
  InstallDir "$PROGRAMFILES64\${NOM_APP}" #Droits admin requis

  ; Récupère le dossier d'installation du registre si l'application est 
  ; déjà installée et écrase la valeur par défaut InstallDir si c'est le cas
  InstallDirRegKey HKCU "Software\${NOM_APP}" ""

  ;Demande de privilège nécessaire pour l'installation
  RequestExecutionLevel admin 

;--------------------------------
;Configuration de l'interface

  ; Permet de demander confirmation avant de quitter l'installateur
  !define MUI_ABORTWARNING  

  ; Forcera l'affichage de la fenêtre de dialogue pour le choix de la langue
  !define MUI_LANGDLL_ALWAYSSHOW
;--------------------------------
;Pages
  !insertmacro MUI_PAGE_LICENSE "license.txt" # Page de licence
  !insertmacro MUI_PAGE_COMPONENTS # Affiche les sections de l'installateur définies ci-bas
  !insertmacro MUI_PAGE_DIRECTORY # Sélection du dossier d'installation

  ;Pour menu démarrer
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\${NOM_APP}" 
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
  !insertmacro MUI_PAGE_STARTMENU Application $DossierMenuDemarrer

  !insertmacro MUI_PAGE_INSTFILES # Installation des fichiers
  
  !insertmacro MUI_UNPAGE_CONFIRM # Confirmation de désinstallation
  !insertmacro MUI_UNPAGE_INSTFILES # Désinstallation des fichiers
  
;--------------------------------
;Langues de l'installateur
  !insertmacro MUI_LANGUAGE "French" # La langue par défaut est la première
  !insertmacro MUI_LANGUAGE "English"
  
;--------------------------------
;Les sections de l'installateur

Section "Meteo" SecComp1

  SetOutPath "$INSTDIR\bin"
  
  ;Ajouter les fichiers à installer
  File /r "..\TP4\bin\Release\net8.0-windows\publish\win-x64\"
  
  ;Ajouter au registre le dossier d'installation
  WriteRegStr HKCU "Software\${NOM_APP}" "" $INSTDIR
  
  ;Créer un désinstallateur
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    ;Création de raccourci dans le menu démarrer
    CreateDirectory "$SMPROGRAMS\$DossierMenuDemarrer"
    CreateShortcut "$SMPROGRAMS\$DossierMenuDemarrer\${NOM_APP}.lnk" "$INSTDIR\bin\${NOM_EXE}.exe"
    CreateShortcut "$SMPROGRAMS\$DossierMenuDemarrer\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  !insertmacro MUI_STARTMENU_WRITE_END

SectionEnd

;--------------------------------
;Les traductions

  ;Les chaînes de traduction
  LangString DESC_SecComp1 ${LANG_FRENCH} "Permet de regarder la météo des 7 jours suivants"
  LangString DESC_SecComp1 ${LANG_ENGLISH} "Let you see the weather for the next 7 days"

  ;Assignation des traduction aux sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecComp1} $(DESC_SecComp1)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Section du désinstallateur

Section "Uninstall"

  ;Suppression du désinstallateur
  Delete "$INSTDIR\Uninstall.exe"
  RMDIR /r "$INSTDIR\bin"
  RMDir "$INSTDIR"

  ;Suppression du menu démarrer
  !insertmacro MUI_STARTMENU_GETFOLDER Application $DossierMenuDemarrer
  Delete "$SMPROGRAMS\$DossierMenuDemarrer\${NOM_APP}.lnk"
  Delete "$SMPROGRAMS\$DossierMenuDemarrer\Uninstall.lnk"
  RMDir "$SMPROGRAMS\$DossierMenuDemarrer"

  ;Suppression au registre des valeurs associées à l'application
  DeleteRegKey /ifempty HKCU "Software\${NOM_APP}"
SectionEnd

;--------------------------------
;Fonction nécessaire pour l'initialisaiton du dialogue de sélection de la langue
Function .onInit
    !insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd