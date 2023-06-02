//
//  CGView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation
import SwiftUI

extension View {
    func asAny() -> AnyView {
        AnyView(self)
    }
}


struct CGView<Content: View>: View {
    init(_ content: @escaping () -> Content) {
        self.content = content
    }
    
    
    var content: () -> Content
    
    
    var body: some View {
        ZStack{
        content()
            .navigationBarHidden(true)
        }
    }
}
