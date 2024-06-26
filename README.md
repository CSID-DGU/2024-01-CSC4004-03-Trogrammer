# 🥗 자취생의 식탁

- 배포 URL : https://drive.google.com/file/d/1GsngZ_ryKLKt1DPAHNTegqP5PRJJRZNt/view?usp=drive_link
- 시연 영상
  냉장고 관리 기능: https://youtu.be/_wFd8GtbEYM
  레시피 찾기 기능: https://youtu.be/udosZAbDur0
  <br>

## 프로젝트 소개

- '자취생의 식탁'은 대학생 1인가구의 알뜰한 식생활을 도와주기 위해 제작된 앱입니다.
- **기능 1**: 사용자가 먹고싶은 음식을 고르면 가격 측면에서 외식과 요리 중 효율적인 선택지를 추천합니다.
- **기능 2**: 사용자의 냉장고 식재료 유통기한 알림 및 냉장고 속 재료로 만들 수 있는 레시피를 제공합니다.
  <br>

## 팀원 구성

<div align="center">

|                                                                 **김가은**                                                                  |                                                                 **이도영**                                                                  |                                                               **이윤석**                                                                |                                                                **정서영**                                                                 |                                                                **조성윤**                                                                |
| :-----------------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------------: | :-------------------------------------------------------------------------------------------------------------------------------------: | :---------------------------------------------------------------------------------------------------------------------------------------: | :--------------------------------------------------------------------------------------------------------------------------------------: |
| [<img src="https://avatars.githubusercontent.com/u/100764111?v=4" height=150 width=150> <br/> @circleolami](https://github.com/circleolami) | [<img src="https://avatars.githubusercontent.com/u/165134940?v=4" height=150 width=150> <br/> @doyoung0627](https://github.com/doyoung0627) | [<img src="https://avatars.githubusercontent.com/u/164312366?v=4" height=150 width=150> <br/> @yslmoment](https://github.com/yslmoment) | [<img src="https://avatars.githubusercontent.com/u/145116577?v=4" height=150 width=150> <br/> @standupnow](https://github.com/standupnow) | [<img src="https://avatars.githubusercontent.com/u/50064865?v=4" height=150 width=150> <br/> @areasplash](https://github.com/areasplash) |

</div>

<br>

## 1. 개발 환경

- **Front**: HTML, Kotlin, C#
- **Back-end**: Java, Spring Boot
- **Database**: MySQL
- **Server**: AWS
- **버전 및 이슈관리**: Github, Github Issues, Github Project
- **협업 툴**: Slack, Notion, Google Drive
- **서비스 배포 환경**:
- **디자인**: Figma
- **Diagram**: Draw.io, mermiad.live
  <br>

## 2. 프로젝트 구조

- **Flowchart**:
  <img width="655" alt="스크린샷 2024-06-08 오후 9 09 30" src="https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/164312366/a042b8b7-997f-4cd8-857d-2cd9114c326e">
  <br>

## 3. 역할 분담

### 🍊 김가은

- **Back-End**
  - 레시피 및 식재료, 음식점 가격을 추출하는 알고리즘 작성
  - 공공데이터 API를 이용한 식재료 가격 불러오기
  - 공공데이터 API를 이용한 레시피 불러오기
  - 프론트앤드와 백엔드 연결
- **DataBase**
  - 전체 DB 구조 설계 및 데이터 입력
    <br>

### 😎 이윤석

- **Design**
  - Draw.io 와 mermaid.live을 이용한 diagram 및 flow chart 제작
  - Figma를 이용한 원하는 음식 선택 및 가격 비교 화면 UI설계
- **Front-End**
  - Andriod Studio를 이용한 원하는 음식 선택 및 가격 비교 화면 UI(xml), 로직(Kotlin) 구현
    <br>

### 👻 조성윤

- **Front-End**
  - Android Studio를 이용한 레시피 검색 페이지 구현
    <br>

## 4. 개발 기간 및 작업 관리

### 개발 기간

- **전체 개발 기간**: 2024-03-11 ~ 2022-06-12
- **주제 선정 및 OSS 조사**: 2024-03-11 ~ 2024-03-29
- **유스케이스 다이어그램 작성**: 2024-03-30 ~ 2024-04-19
- **문제 기술서 작성**: 2024-03-30 ~ 2024-04-05
- **시퀀스, 상태, 클래스 다이어그램 작성**: 2024-04-02 ~ 2024-04-19
- **UI 디자인 및 설계**: 2024-03-30 ~ 2024-04-19
- **UI 구현**: 2024-04-15 ~ 2024-04-21
- **DB 데모코드 작성**: 2024-04-29 ~ 2024-05-11
- **DB 구현**: 2024-04-02 ~ 2024-05-31
- **프론트엔드, 백엔드 연동 및 피드백**: 2024-05-06 ~ 2024-06-12
- **최종 결과물 발표**: 2024-06-13
  <br>

### 작업 관리

- Github branch를 나누어 섹션별로 작업을 진행했습니다.
- Notion 백로그를 이용하여 일정 별 할 일과 진행도를 확인하였습니다.
- 매주 주간회의를 통해 각 파트별 진행상황과 앞으로 구현해야 할 일을 점검하였습니다.
  <br>

## 5. 페이지별 기능

### 초기화면

![Screenshot_20240609_023736_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/231e153a-6986-4692-abf4-4aa2ad4ca202)

- 사용자가 앱을 실행시키면 냉장고 관리하기와 레시피 찾기 버튼 중 하나를 선택할 수 있습니다.
  <br>

### 냉장고 관리 화면

![Screenshot_20240609_023741_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/36658750-ec81-4c4c-9b89-c001a191aae5)
![Screenshot_20240609_023838_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/471c5b06-e7e2-404a-b40b-61b65062e565)

- 사용자가 직접 냉장고에 식재료를 추가할 수 있으며, 식재료 유통기한을 설정하지 않거나, 유통기한 날짜 양식을 지키지 않을 시, 기본 유통기한으로 입력됩니다.
- 유통기한 3일 미만 식재료를 따로 분리하여 나타내, 사용자가 식재료를 낭비하지 않도록 하였습니다.

### 레시피 탐색 화면

![Screenshot_20240609_023847_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/06976668-ad43-443e-93c7-a1626a77e2ae)
![Screenshot_20240609_023854_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/5da8648a-19e1-41aa-9268-9c90e0202766)
![Screenshot_20240609_023906_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/0930ca7a-f734-4cd3-8955-087bfbf36fd7)

- 사용자가 원하는 음식을 상단의 검색 탭에 입력하면, 음식을 만들기 위해 필요한 식재료와 레시피가 뜨도록 구현했습니다.
- 한식, 중식, 일식, 양식 카테고리로 음식을 분리하여, 사용자가 검색하는 것 대신 앱을 둘러보면서 음식을 클릭할 수 있도록 구현했습니다.
- 근처 음식점과 비교하기 버튼을 클릭하여 외식을 하는 것과 직접 만들어먹는 비용을 사용자 스스로 비교할 수 있습니다.

### 근처 식당 비교 화면

![Screenshot_20240609_023925_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/54edb875-77f8-4827-8a3e-c0222298037b)
![Screenshot_20240609_025218_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/4944f845-9678-4b28-8745-ad6f9a4aa4b7)
![Screenshot_20240609_025256_OpenSW](https://github.com/CSID-DGU/2024-01-CSC4004-03-Trogrammer/assets/50064865/248dd9a0-6792-437f-80ff-506bfa535dd5)

- 근처 음식점의 외식 가격과 식재료를 구매하는 비용을 비교하여 더 경제적인 방법을 선택할 수 있습니다.
- 사용자의 냉장고에 있는 식재료를 배제하고 구매 식재료를 표시하여, 불필요한 식재료 구매를 막을 수 있도록 하였습니다.
- 구매해야 하는 식재료의 쿠팡 링크를 삽입하여, 간편하게 식재료를 구매할 수 있도록 유도하였습니다.
- 가장 저렴한 근처 식당 위치를 네이버 지도로 볼 수 있도록 버튼을 구현하였습니다.

## 6. 프로젝트 후기

### 🍊 김가은

동국대/충무로에 거주하고 있는 자취생으로서, 평소 경험을 바탕으로 자취생에게 필요하다고 생각하는 기능을 담은 '자취생의 식탁'이라는 프로젝트 주제를 제시하였다. 직접 필요한 기능을 담은 앱을 만들면서, 학교 수업에서 배운 컴퓨터지식을 이용해 내가 생각만 하고 있었던 앱을 제작할 수 있다는 것을 알게 되었다. 처음 만드는 앱이라 DB 설계부터 알고리즘 제작, API 제작까지 많은 시행착오가 있었지만, 이번 프로젝트를 통해 프레임워크와 데이터베이스, API의 동작 방법에 대해 확실히 이해하게 되었다. 또한, 프론트엔드와의 협업을 통해 여러 명이서 개발을 할 때 어떻게 소통을 해야하는지, 깃은 어떻게 사용하는지를 알게 되었다. 이번 프로젝트를 통해 앱 개발에 대한 자신감을 얻게 되었다.
<br>

### 👻 이도영

자취생의 식비 절감이라는 목표로 시작한 프로젝트 '자취생의 식탁'에서 프론트 엔드를 맡으며 앱 개발을 진행했다. 개발자로서 자취하는 대학생의 경제적 부담이라는 사회 문제를 해결할 수 있는 것에 조금이나마 도움이 된 것 같아 의미 있는 개발을 할 수 있었다. 앱 개발에 있어 코딩뿐만 아니라 UI 설계와 DB의 필요성 등 여러적인 요소가 복합적으로 중요하다는 것을 깨달았다. 앞으로 이번 프로젝트와 유사한 사회 현상을 해결하는 프로젝트를 진행하고 싶다.
<br>

### 😎 이윤석

이번 프로젝트에서 프론트 개발의 팀원으로서 참여하게 되었다. 앱 개발경험은 두번째였으며 Android Studio의 사용은 처음이었기에 학기 중 개인적인 학습을 통하여 더 효율적인 로직구현을 성공하기 위하여 노력했다. 특히 학기 중 Kotlin 언어의 학습이 꽤나 어려웠기 때문에 많은 난항을 겪었고 이를 스터디를 통하여 극복하고자 하였다. 또한 기존의 SW개발지식을 바탕으로 다양한 UML Diagram 제작의 중요성을 다시한번 느끼게 되었으며, 앞으로의 프로젝트에 있어서도 단순 코드구현보다 설계에 더 중점적으로 많은 생각을 요해야겠다는 생각이 들었다.
<br>

### 🐬 정서영

'자취생의 식탁' 프로젝트의 '사용자 냉장고 관리' 기능의 백엔드 개발을 맡으며, 사용자 냉장고 데이터 관리와 OPEN API를 통한 레시피 추천 알고리즘 구현에 중점을 두었다. 사용자 냉장고 식재료 기반 레시피 제공으로 사용자 편의를 극대화하도록 노력했다. 이 프로젝트의 백엔드 개발에서 DB 설계, OPEN API 이용법, 프레임워크와 서버 구조에 더하여 팀원들과의 협력과 소통까지 직접 모두 해보면 많은 경험을 쌓을 수 있었다.
<br>

### 👻 조성윤

올 학기 공개SW프로젝트 수업에서 팀음 이뤄 프로젝트 개발을 진행하면서, 다양한 좋은 경험을 할 수 있었다. 실제 프로젝트의 개발 과정에서 오픈 소스를 이용할 때 오픈소스의 강점과 활용 방법을 배울 수 있었다. 프론트엔드 부문을 맡아 프로젝트의 여러 기능을 함께 구현하면서 본인의 협업 능력, 의사소통 능력 정도를 확인할 수 있었다. 프로젝트를 진행함에 있어 중점으로 맡았던 UI 디자인, 로직 설계 부분에서는 일정의 한계로 아쉬움을 느꼈고 이를 반면교사 삼아 다음 프로젝트 활동 때 보완키로 하였다.
