# SW_Basic_Design
SW Basic Design Lecture for Sejong Uni. Software Major 2024-02

## What is?
 Unity를 이용한 2D 장애물 피하기 & 리듬 게임으로 박자에 맞게 장애물을 피하거나, 적에게 패링하며 스테이지를 클리어 해나가는 게임입니다.

## How?
 - 장애물 생성<br>모든 장애물은 스테이지 곡의 bpm에 맞게 공격 속도가 변합니다.<br><br>
 - 장애물 생성(가시)<br>회전하는 두 플랫폼에 부착되어 같이 회전합니다. bpm에 맞게 가시 생성 위치가 결정되어, 항상 일정한 박자 이후에 플레이어 위치로 도달합니다.<br><br>
 - 장애물 생성(화염구)<br>화염구 생성 위치와 플레이어 위치 통해 화염구가 이동합니다.<br><br>
 - 장애물 생성(범위 공격 및 플랫폼 공격)<br>일정한 박자 이후 붉은 지점에 닿으면 공격을 받습니다. 노란 색으로 깜빡이며 위험한 구역을 알립니다.<br><br>
 - 플레이어 움직임(텔레포트 및 패링)<br>space를 눌러 텔레포트하고 Lshift를 눌러 패링합니다.<br><br>
 - 패링<br>화염구와 플레이어가 일정 거리 안에 들어왔을 때 패링이 가능합니다. 1~4 스테이지의 경우 자동으로 패링되나, 4Hard 스테이지의 경우 마우스 포인터 위치로 패링됩니다.<br><br>
 - 아이템(증표)<br>증표의 경우 플레이어와 접촉하면 획득할 수 있습니다. 증표를 모아 보스전에 도전할 수 있습니다.<br><br>
 - 스테이지 클리어<br>일반 스테이지의 경우 곡이 끝날 때까지 생존하면 클리어합니다. 챕터 1의 하드 스테이지 이후부터는 곡이 끝나기 전 적과의 전투에서 승리하면 클리어합니다.<br><br>

## Play Video
[![프로젝트 시연](https://img.youtube.com/vi/SgMVQtrweXw/0.jpg)](https://www.youtube.com/watch?v=SgMVQtrweXw)
