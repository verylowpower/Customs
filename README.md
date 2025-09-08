# 📦 CUSTOMS

## 🎮 Giới thiệu

Đây là một game **Visual Novel kết hợp Point & Click** được phát triển bằng Unity.
Người chơi sẽ trải qua nhiều **ngày (Day system)**, mỗi ngày chứa các **package** (gói thông tin: mô hình 3D, note, news).
Thông qua việc tương tác và đưa ra lựa chọn (**Choice System**), người chơi sẽ dần tích lũy điểm số ảnh hưởng đến **Ending System** với nhiều kết cục khác nhau.

---

## ✨ Tính năng chính

* **Day & Package System**

  * Mỗi ngày được load từ prefab.
  * Package chứa mô hình 3D, note, và news.
  * Người chơi có thể mở, xem, và tương tác.

* **Choice System**

  * Khi đến các tình huống quan trọng, người chơi đưa ra lựa chọn (Accept / Deny / Skip).
  * Quyết định sẽ thay đổi nhánh câu chuyện.

* **Dialogue System**

  * Hỗ trợ hội thoại động.
  * Có thể tự động kích hoạt hoặc tương tác thông qua các object.

* **Progress & Ending Manager**

  * Tích lũy điểm số theo từng EndingType (Prison, Death, Promote, Schrodinger, Ado, Normal).
  * Kết thúc sẽ hiển thị Ending tương ứng.
  * Sau khi kết thúc, game tự động trở về Menu.

* **Save & Reset**

  * Người chơi có thể reset về **Day 0** để chơi lại từ đầu.
  * Khi chọn **Start** trong Menu → game load lại scene chính hoàn toàn mới.

---

## 🛠️ Công nghệ

* **Unity** (2021+)
* **C#** scripting
* **TextMeshPro** cho UI
* **ScriptableObject** để lưu trữ dữ liệu ngày (DayData)
* **Prefab-based system** cho quản lý package


---

## 🚀 Cách chơi

1. **Start Game** từ Menu.
2. Trải qua từng ngày, mở các package, đọc note/news, và quan sát mô hình 3D.
3. Đưa ra quyết định khi có **Choice Event**.
4. Sau khi qua nhiều ngày, game sẽ dẫn đến một trong các **Ending**.
5. Game tự động trở về Menu → người chơi có thể bắt đầu lại.

---

## 📌 Đặc biệt

* Hệ thống **Day & Package** được thiết kế **tự động load prefab**, dễ mở rộng thêm nội dung mới.
* **Choice + Ending System** có thể coi là một **Narrative Decision Framework**, có thể tái sử dụng trong các dự án khác.
