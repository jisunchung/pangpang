
# 팡팡이의 대모험
유니티를 활용한 게임

**제목 :**  팡팡이의 모험

**캐릭터 소개 :** 팡팡이 – 곰팡이에서 아이디어를 얻어 만든 캐릭터, 악당들은 채소들로 구성    
<img width="288" alt="image" src="https://github.com/user-attachments/assets/3a06d28c-499a-44e7-b5b7-037c598f7bc9">

**게임 소개 :** 미니게임을 통해 얻은 코인을 모아 캐릭터의 키운다
	   로그인과 랭킹, shop을 구현하여 자신만의 팡팡이를 만들 수 있다.
    
## 기술 스택
- **Unity**
- **C#**
- **Firebase** (랭킹 및 사용자 데이터 관리)

---

![슬라이드1](https://github.com/user-attachments/assets/3a8e451f-e8ae-4db2-bc9c-9d9fcd778cb5)
![슬라이드2](https://github.com/user-attachments/assets/d7285f69-8c19-465e-bf34-6b3d8e047448)
![슬라이드3](https://github.com/user-attachments/assets/515473c3-5978-4b99-ad1d-8d5c11c32221)
![슬라이드5](https://github.com/user-attachments/assets/b77a83ec-28de-4585-b680-e47655a9345c)
![슬라이드6](https://github.com/user-attachments/assets/b14ac4ae-7a76-41d7-a91d-f290df57b071)
![슬라이드7](https://github.com/user-attachments/assets/3ed20be7-7c7b-41ef-a2c1-412f067dffa5)
![슬라이드8](https://github.com/user-attachments/assets/1589b9b9-16b5-4837-8b62-4886b8070d18)
![슬라이드9](https://github.com/user-attachments/assets/f0caa96b-2502-44ee-a526-1fecbfc7c955)
![슬라이드10](https://github.com/user-attachments/assets/bcd2fd16-831e-4e54-95c4-67c29f6cdd20)
![슬라이드11](https://github.com/user-attachments/assets/fbe58919-0209-47c3-87e4-3c7600692101)
![슬라이드12](https://github.com/user-attachments/assets/18511149-f42f-451f-b435-f353b90cd2c8)
![슬라이드13](https://github.com/user-attachments/assets/2bae4c91-e5a8-41fb-ad4a-9399c06868ac)
![슬라이드14](https://github.com/user-attachments/assets/8b8e9e27-179a-44e7-8012-9ce9a779ed97)
![슬라이드15](https://github.com/user-attachments/assets/54151051-5d00-4aea-8eca-66aa822027ac)
![슬라이드16](https://github.com/user-attachments/assets/ca52fd68-5819-484d-b1ce-29ee78d62c54)
![슬라이드17](https://github.com/user-attachments/assets/660d3133-ddd1-48a4-8e74-a3018b93c96b)
![슬라이드18](https://github.com/user-attachments/assets/6560824f-ce49-4e5f-9d10-4ab65edb1ca5)
![슬라이드19](https://github.com/user-attachments/assets/e5968f62-55ab-46d0-8c54-e9a8d2c21e55)
![슬라이드20](https://github.com/user-attachments/assets/696bbeb6-691e-41d2-afba-f4d3396f0148)


### 시연영상
https://github.com/user-attachments/assets/5c381ef3-ab10-4a6b-b3a4-2c19c16a09e5

### 캐릭터 구현 (피망)
"피망" 캐릭터는 고유한 능력을 가지고 있으며, 체력이 일정 수준 이하로 떨어지면 색이 변하고 사라졌다가 다시 나타나는 기능이 있습니다. 

**코드 예시 (피망 색상 변경 및 페이드 효과):**
```csharp
private void ColorChange() {
    if (HP < 0.5) {
        spriteResolver.SetCategoryAndLabel("Pimang", "PimangRed");
    }
}

private IEnumerator Fade(float start, float end) {
    float currentTime = 0f;
    while (currentTime < fadeTime) {
        currentTime += Time.deltaTime;
        float alphaValue = Mathf.Lerp(start, end, currentTime / fadeTime);
        SetAlpha(alphaValue);  // 알파 값을 설정하여 페이드 효과 구현
        yield return null;
    }
}

private IEnumerator FadeInOut() {
    yield return StartCoroutine(Fade(1, 0));  // 페이드 아웃
    yield return new WaitForSeconds(1);
    // 캐릭터를 랜덤한 위치로 이동
    transform.position = GetRandomPosition();
    yield return StartCoroutine(Fade(0, 1));  // 페이드 인
}
```

### 홈 화면 관리
홈 화면에서는 패널 전환을 통해 사용자 인터페이스를 관리합니다. 각 패널은 `SetActive` 메서드를 사용하여 화면 전환을 구현합니다.

**코드 예시 (홈 화면 패널 전환):**
```csharp
[SerializeField] private GameObject rankingPanel;
[SerializeField] private GameObject shopPanel;

public void ShowRankingPanel() {
    rankingPanel.SetActive(true);
    shopPanel.SetActive(false);
}

public void ShowShopPanel() {
    rankingPanel.SetActive(false);
    shopPanel.SetActive(true);
}
```

### 랭킹 시스템
Firebase를 사용하여 게임 내 랭킹을 관리합니다. 사용자의 점수를 불러와 내림차순으로 정렬한 후 상위 5명의 유저를 화면에 출력합니다.

**코드 예시 (Firebase에서 랭킹 데이터 불러오기):**
```csharp
FirebaseDatabase db = FirebaseDatabase.DefaultInstance;
DatabaseReference reference = db.GetReference("users");

reference.OrderByChild("score").LimitToFirst(5).GetValueAsync().ContinueWith(task => {
    if (task.IsCompleted) {
        DataSnapshot snapshot = task.Result;
        // 랭킹 정보를 리스트에 저장하여 화면에 출력
    }
});
```

### 상점 시스템
유저가 상점에서 아이템을 구매하고, 구매한 아이템은 Firebase에 저장됩니다. 이미 구매한 아이템은 잠금 해제된 상태로 표시됩니다.

**코드 예시 (상점 아이템 잠금 해제):**
```csharp
public void UnlockItem(int itemId) {
    if (playerCoins >= itemPrice[itemId]) {
        playerCoins -= itemPrice[itemId];
        playerItems[itemId] = true;  // 아이템 구매
        UpdateFirebaseData();        // Firebase에 데이터 업데이트
    } else {
        Debug.Log("잔액이 부족합니다.");
    }
}
```

