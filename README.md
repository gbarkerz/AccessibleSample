# Accessible Sample

This app demonstrates some fundamental steps around making UWP and .NET MAUI apps accessible to more people.

The app solution was created with Visual Studio Community 2022 V17.7.0 Preview 2.0. The UWP project targets Windows 11 V22H2 (10.0; Build 22621), with a min version of Windows 10, V1809 (10.0; Build 17763). The MAUI project builds for Windows and Android, targeting .NET 8.0.

## Introduction (Written 14th July 2023)

I recently downloaded Store apps to my Windows device and found them inaccessible due to fundamental bugs such as Button names and Item names supplied to screen readers being either missing or meaningless. So I created this app which demonstrates simple steps to set helpful names on Buttons and Items which can be announced by screen readers. 

The UI platforms used by the apps support many additional features relating to making apps more accessible to more people, but this app intentionally focuses only on setting accessible names on controls. Note that the step shown relating to setting an accessible name on a Button also works with many other types of controls.

One of the apps I downloaded from the Store contained UI that was visually presented as a Button, but was in fact a tappable text label with a border. This sort of UI is inaccessible to many people, including those who use a keyboard. A fundamental requirement in creating accessible UI is to use controls that are the closest semantic match for the app. For more thoughts on that subject, visit the “Semantic Controls” section at [Considerations Around Building an Accessible Multi-platform App](https://www.linkedin.com/pulse/considerations-around-building-accessible-app-guy-barker).

## App control accessibility

Each app in this sample first shows a set of controls whose names are missing or meaningless to screen readers, followed by a set of the same controls which do have helpful names set for screen readers. The comments in the projects’ main.xaml files provide more information around how and why specific names were set. 

Note that some screen readers on some platforms take action to try to compensate for the inaccessibility of apps. For example, if an Item has no accessible name, some screen readers may search for text contained within the Item and repurpose that text as the name of the Item. Relying on screen readers to try to work around the inaccessibility of an app will not lead to a satisfactory user experience, and as such, it is the responsibility of the app builder to proactively build a quality experience for all the app’s users.

The following two Windows screenshots show the Accessibility Insights for Windows tool reporting the programmatic representation of the UWP and Windows MAUI app UI. It is this representation that Windows screen readers access to make announcements to users. Accessibility Insights reports that the app’s inaccessible Buttons have no names, and the inaccessible Items have names made up of the app code’s namespaces and class names. It also reports that the accessible Buttons and Items all have helpful names which contain the full data required by users. 

![Accessibilty Insights reporting the programmatic representation of the UWP app running in dark mode](/Screenshots/SampleAppUWP_A11yInsights.png)

![Accessibilty Insights reporting the programmatic representation of the Windows MAUI app running in dark mode](/Screenshots/SampleAppMAUI_A11yInsights.png)

The following two Windows screenshots show the NVDA screen reader’s Speech Viewer feature reporting the announcements made as keyboard focus moves through the controls in the UWP app and Windows MAUI app. The announcement made at an inaccessible Button (which shows only an image) is “button”, with no additional data conveying the purpose of the button. Announcements made at inaccessible Items (which show text and one or more images) include: “AccessibleSampleUWP.SampleItemFestival 1 of 2”, and “Microsoft.Maui.Control.Platform.ItemTemplateContext 2 of 2”. The announcement made at an accessible Button (which shows only an image) is “Play button”. Announcements made at accessible Items (which show text and one or more images) include: “bluedot 1 of 2”, and “Here Comes the Sun, not available 1 of 2”.

![The NVDA Speech Viewer reporting the screen reader announcements made while keyboard focus moves through the UWP app running in light mode](/Screenshots/SampleAppUWP_NVDA.png)

![The NVDA Speech Viewer reporting the screen reader announcements made while keyboard focus moves through the Windows MAUI app running in light mode](/Screenshots/SampleAppMAUI_NVDA.png)

The following two Android screenshots show the TalkBack screen reader highlighting controls in the app. In one screenshot, TalkBack is highlighting a Button which contains an image with no text, and TalkBack’s caption shows: “Play, Button, Out of list”. In the other screenshot, TalkBack is highlighting an Item which shows text and two images, and TalkBack’s caption shows: “Here Comes the Sun, not available”.

![The TalkBack screen reader's caption showing the announcement made at a Button in the Android MAUI app running in light mode](/Screenshots/SampleAppAndroid_TalkBack_Light.jpg)

![The TalkBack screen reader's caption showing the announcement made at an Item in the Android MAUI app running in dark  mode](/Screenshots/SampleAppAndroid_TalkBack_Dark.jpg)
