using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

  
    [SerializeField]
    private string m_fileName = null;
    [SerializeField]
    private string m_directory = null;
    [SerializeField]
    private string m_arguments = null;
    [SerializeField]
    private bool m_hidden = false;

    private System.Diagnostics.Process m_process = null;


    private void Start()
    {
        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();

        // 実行ファイル名
        info.FileName = m_fileName;
        // 実行フォルダ
        info.WorkingDirectory = string.Format(@"{0}\{1}", Application.streamingAssetsPath, m_directory);
        // 実行ファイルに渡す引数
        info.Arguments = m_arguments;
        // 実行ファイルを隠すか普通に表示するか
        info.WindowStyle = m_hidden ? System.Diagnostics.ProcessWindowStyle.Hidden : System.Diagnostics.ProcessWindowStyle.Normal;

        try
        {
            m_process = System.Diagnostics.Process.Start(info);
        }
        catch (System.ComponentModel.Win32Exception i_exception)
        {
            Debug.Assert(false, i_exception);
            m_process = null;
        }
    }

    private void OnDestroy()
    {
        if (m_process == null)
        {
            return;
        }

        // まだプロセスが閉じていないなら、強制的に消す
        if (!m_process.HasExited)
        {
            m_process.Kill();
        }

        // Dispose メソッドは Close を呼び出します。 配置すること、 Process 内のオブジェクト、 using ブロックを呼び出すことがなくリソースを破棄 Closeする
        // MSDNには上記のようにDispose()内でClose()を呼ぶらしいから、Dispose()だけでいいと思っているんだけど、
        // Close()とDispose()を連続で呼んでいる、コードを見たことあるんだよなぁ。

        
        m_process.Dispose();

        m_process = null;
    }

}
