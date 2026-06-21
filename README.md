# UnityClickerGame

Unity 6.0 の WebGL 向けプロジェクトです。

## 確認済み環境

- Unity Editor: `6000.5.0f1`
- Render Pipeline: Universal Render Pipeline `17.5.0`
- ビルド対象: WebGL

## 構成

- `Assets/Scenes/MainScene.unity`: ビルド設定に登録されているメインシーン
- `Assets/UI/MainScene.uxml`: UI Toolkit の画面定義
- `Assets/UI/MainScene.uss`: UI Toolkit のスタイル定義

## WebGL ビルド

Unity のバッチモードから次の Editor メソッドを実行すると、`Build` ディレクトリに WebGL ビルドを出力します。

```sh
Unity -batchmode -quit -projectPath . -executeMethod CodexWebGLBuild.Build
```

ビルド対象シーンは `Assets/Scenes/MainScene.unity` です。

## GitHub Pages への自動公開

`main` ブランチへ push されると、`.github/workflows/deploy-pages.yml` により WebGL ビルドを作成し、GitHub Pages へ公開します。

GitHub 側では次の設定が必要です。

1. Repository の `Settings` > `Pages` を開く。
2. `Build and deployment` の `Source` を `GitHub Actions` にする。
3. Repository の `Settings` > `Secrets and variables` > `Actions` を開く。
4. `Repository secrets` に `UNITY_LICENSE`、`UNITY_EMAIL`、`UNITY_PASSWORD` を登録する。
5. `main` ブランチへ commit/push する。

- `UNITY_LICENSE`: Unity_lic.ulfファイルの中身
- `UNITY_EMAIL`: Unity アカウントのメールアドレス
- `UNITY_PASSWORD`: Unity アカウントのパスワード
